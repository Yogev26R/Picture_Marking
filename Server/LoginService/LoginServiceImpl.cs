using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.User;
using PictureMarkingContracts.Interface;
using System;

namespace LoginService
{
    [Register(Policy.Transient, typeof(ILoginService))]
    public class LoginServiceImpl : ILoginService
    {
        IUserDAL _dal;

        public LoginServiceImpl(IUserDAL dal)
        {
            _dal = dal;
        }

        public Response Login(LoginRequest request)
        {
            try
            {
                var ds = _dal.ReadUserByUserName(request.Login.UserName);
                var tbl = ds.Tables[0];
                LoginResponse retval = new LoginResponseInvalidUserName(request);
                if (tbl.Rows.Count == 1)
                {
                    var userName = (string)tbl.Rows[0]["USER_NAME"];
                    var isRemoved = Convert.ToInt32((Int16)tbl.Rows[0]["IS_REMOVED"]);
                    if (request.Login.UserName == userName && isRemoved == 0)
                    {
                        request.UserID = (string)tbl.Rows[0]["USER_ID"];
                        retval = new LoginResponseOK(request);
                    }
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
