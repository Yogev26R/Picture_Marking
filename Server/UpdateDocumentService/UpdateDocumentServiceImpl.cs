using Contracts.DTO;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface;
using PictureMarkingContracts.Interface.Document;
using System;

namespace UpdateDocumentService
{
    public class UpdateDocumentServiceImpl : IUpdateDocumentService
    {
        IUserDAL _dal;

        public UpdateDocumentServiceImpl(IUserDAL dal)
        {
            _dal = dal;
        }

        public Response UpdateDocument(UpdateDocumentRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
