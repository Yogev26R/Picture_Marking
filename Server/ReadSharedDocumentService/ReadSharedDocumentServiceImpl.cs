using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface.DAL;
using PictureMarkingContracts.Interface.SharedDocument;
using System;
using System.Collections.Generic;
using System.Data;

namespace ReadSharedDocumentService
{
    [Register(Policy.Transient, typeof(IReadSharedDocumentService))]
    public class ReadSharedDocumentServiceImpl : IReadSharedDocumentService
    {
        ISharedDocumentDAL _sharedDocDAL;
        IDocumentDAL _docDAL;

        public ReadSharedDocumentServiceImpl(ISharedDocumentDAL sharedDocDAL, IDocumentDAL docDAL)
        {
            _sharedDocDAL = sharedDocDAL;
            _docDAL = docDAL;
        }

        public Response ReadSharedDocuments(ReadSharedDocumentsRequest request)
        {
            try
            {
                var sharedDocDS = _sharedDocDAL.ReadSharedDocuments(request.userID);
                var sharedDocTBL = sharedDocDS.Tables[0];

                ReadSharedDocumentsResponseOK retval = new ReadSharedDocumentsResponseOK(request);

                if (sharedDocTBL.Rows.Count > 0)
                {
                    List<DocumentDTO> list = new List<DocumentDTO>();
                    foreach (DataRow sharedDocRow in sharedDocTBL.Rows)
                    {
                        var SharedDocumentID = sharedDocRow["Document_ID"].ToString();
                        var docDS = _docDAL.ReadDocument(SharedDocumentID);
                        var docTBL = docDS.Tables[0];
                        var docRow = docTBL.Rows[0];
                        DocumentDTO document = new DocumentDTO()
                        {
                            OwnerID = docRow["OWNER_ID"].ToString(),
                            ImageURL = docRow["IMAGE_URL"].ToString(),
                            DocumentName = docRow["DOCUMENT_NAME"].ToString(),
                            DocumentID = SharedDocumentID
                        };
                        list.Add(document);
                    }

                    request.documents = list.ToArray();
                    retval = new ReadSharedDocumentsResponseOK(request);
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
