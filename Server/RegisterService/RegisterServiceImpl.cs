using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.User;
using PictureMarkingContracts.Interface;
using System;

namespace RegisterService
{

    [Register(Policy.Transient, typeof(IRegisterService))]
    public class RegisterServiceImpl : IRegisterService
    {
        IUserDAL _dal;

        public RegisterServiceImpl(IUserDAL dal)
        {
            _dal = dal;
        }

        public Response Register(RegisterRequest request)
        {
            try
            {
                var dsUserID = _dal.ReadUserByUserID(request.Register.UserID);
                var tblUserID = dsUserID.Tables[0];
                var dsUserName = _dal.ReadUserByUserName(request.Register.Login.UserName);
                var tblUserName = dsUserName.Tables[0];

                RegisterResponse retval = new RegisterResponseEmailAddressExists(request);
                if (tblUserName.Rows.Count == 1)
                {
                    retval = new RegisterResponseUserNameExists(request);
                }
                else if (tblUserID.Rows.Count == 0)
                {
                    _dal.CreateUser(request.Register);
                    retval = new RegisterResponseOK(request);
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
