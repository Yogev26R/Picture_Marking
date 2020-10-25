using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.SharedDocument;
using PictureMarkingContracts.Interface;
using PictureMarkingContracts.Interface.DAL;
using PictureMarkingContracts.Interface.SharedDocument;
using System;

namespace CreateSharedDocumentService
{
    [Register(Policy.Transient, typeof(ICreateSharedDocumentService))]

    public class CreateSharedDocumentServiceImpl : ICreateSharedDocumentService
    {
        ISharedDocumentDAL _sharedDocDAL;
        IUserDAL _UserDAL;

        public CreateSharedDocumentServiceImpl(ISharedDocumentDAL sharedDocDAL, IUserDAL UserDAL)
        {
            _sharedDocDAL = sharedDocDAL;
            _UserDAL = UserDAL;
        }

        public Response CreateSharedDocument(CreateSharedDocumentRequest request)
        {
            try
            {
                CreateSharedDocumentResponse retval;

                var userDS = _UserDAL.ReadUserByUserName(request.SharedDocument.UserName);
                var userTBL = userDS.Tables[0];
                if(userTBL.Rows.Count == 0)
                {
                    retval = new CreateSharedDocumentResponseInvalidUserName(request);
                } else
                {
                    var userID = userTBL.Rows[0]["USER_ID"];
                    var userName = request.SharedDocument.UserName;
                    request.SharedDocument.UserName = userID.ToString();
                    var sharedDocDS = _sharedDocDAL.CreateSharedDocument(request.SharedDocument);
                    request.SharedDocument.UserName = userName;
                    retval = new CreateSharedDocumentResponseOK(request);
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
