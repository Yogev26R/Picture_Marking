using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface.DAL;
using PictureMarkingContracts.Interface.Document;
using System;

namespace DeleteDocumentService
{
    [Register(Policy.Transient, typeof(IDeleteDocumentService))]
    public class DeleteDocumentServiceImpl : IDeleteDocumentService
    {
        IDocumentDAL _dal;

        public DeleteDocumentServiceImpl(IDocumentDAL dal)
        {
            _dal = dal;
        }
        public Response DeleteDocument(DeleteDocumentRequest request)
        {
            try
            {
                var ds = _dal.ReadDocument(request.Document.DocumentID);
                var tbl = ds.Tables[0];

                DeleteDocumentResponse retval = new DeleteDocumentResponseInvalidDocumentID(request);
                if (tbl.Rows.Count == 1)
                {
                    retval = new DeleteDocumentResponseOK(request);
                    _dal.DeleteDocument(request.Document);
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
