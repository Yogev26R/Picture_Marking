using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.Document;
using PictureMarkingContracts.Interface;
using PictureMarkingContracts.Interface.DAL;
using PictureMarkingContracts.Interface.Document;
using System;

namespace CreateDocumentService
{
    [Register(Policy.Transient, typeof(ICreateDocumentService))]
    public class CreateDocumentServiceImpl : ICreateDocumentService
    {
        IDocumentDAL _dal;
        IIDGeneratorService _idGenerator;

        public CreateDocumentServiceImpl(IDocumentDAL dal, IIDGeneratorService idGenerator)
        {
            _dal = dal;
            _idGenerator = idGenerator;
        }

        public Response CreateDocument(CreateDocumentRequest request)
        {
            try
            {
                var ds = _dal.ReadDocument(request.Document.DocumentName);
                var tbl = ds.Tables[0];

                CreateDocumentResponse retval = new CreateDocumentResponseDocumentNameExists(request);
                if (tbl.Rows.Count == 0)
                {
                    retval = new CreateDocumentResponseOK(request);
                    request.Document.DocumentID = _idGenerator.GenerateID(request.Document.DocumentName);
                    _dal.CreateDocument(request.Document);
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
