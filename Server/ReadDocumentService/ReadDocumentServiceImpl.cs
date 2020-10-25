using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface.DAL;
using PictureMarkingContracts.Interface.Document;
using System;
using System.Collections.Generic;
using System.Data;

namespace ReadDocumentService
{
    [Register(Policy.Transient, typeof(IReadDocumentService))]
    public class ReadDocumentServiceImpl : IReadDocumentService
    {
        IDocumentDAL _dal;

        public ReadDocumentServiceImpl(IDocumentDAL dal)
        {
            _dal = dal;
        }

        public Response ReadDocument(string documentID)
        {
            try
            {
                var ds = _dal.ReadDocuments(documentID);
                var tbl = ds.Tables[0];

                ReadDocumentRequest request = new ReadDocumentRequest();
                ReadDocumentResponse retval = new ReadDocumentResponseInvalidDocumentID(request);
                if (tbl.Rows.Count == 1)
                {
                    var row = tbl.Rows[0];
                    DocumentDTO document = new DocumentDTO()
                    {
                        OwnerID = row["OWNER_ID"].ToString(),
                        ImageURL = row["IMAGE_URL"].ToString(),
                        DocumentName = row["DOCUMENT_NAME"].ToString(),
                        DocumentID = row["Document_ID"].ToString()
                    };
                    request = new ReadDocumentRequest() { Document = document };
                    retval = new ReadDocumentResponseOK(request);
                }

                return retval;
            }
            catch (Exception ex)
            {
                return new ErrorResponse(ex.Message);
            }
        }
        public Response ReadDocuments(ReadDocumentsRequest request)
        {
            try
            {
                var ds = _dal.ReadDocuments(request.userID);
                var tbl = ds.Tables[0];

                ReadDocumentsResponse retval = new ReadDocumentsResponseInvalidUserName(request);
                if (tbl.Rows.Count >= 0)
                {
                    List<DocumentDTO> list = new List<DocumentDTO>();
                    foreach (DataRow row in tbl.Rows)
                    {
                        DocumentDTO document = new DocumentDTO()
                        {
                            OwnerID = row["OWNER_ID"].ToString(),
                            ImageURL = row["IMAGE_URL"].ToString(),
                            DocumentName = row["DOCUMENT_NAME"].ToString(),
                            DocumentID = row["Document_ID"].ToString()
                        };
                        list.Add(document);
                    }
                    request.documents = list.ToArray();
                    retval = new ReadDocumentsResponseOK(request);
                }
                return retval;
            }

            catch (Exception ex)
            {
                return new ErrorResponse(ex.Message);
            }
        }
    }
}