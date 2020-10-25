using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.User;
using PictureMarkingContracts.Interface;
using System;

namespace UnSubscribeService
{
    [Register(Policy.Transient, typeof(IUnSubscribeService))]
    public class UnSubscribeServiceImpl : IUnSubscribeService
    {
        IUserDAL _dal;
        public UnSubscribeServiceImpl(IUserDAL dal)
        {
            _dal = dal;
        }

        public Response UnSubscribe(UnSubscribeRequest request)
        {
            try
            {
                var dsUserID = _dal.ReadUserByUserID(request.UnSubscribe.UserID);
                var tblUserID = dsUserID.Tables[0];
                var dsUserName = _dal.ReadUserByUserName(request.UnSubscribe.Login.UserName);
                var tblUserName = dsUserName.Tables[0];

                UnSubscribeResponse retval = new UnSubscribeResponseInvalidEmailAddress(request);
                if (tblUserName.Rows.Count == 0)
                {
                    retval = new UnSubscribeResponseInvalidUserName(request);
                }
                else if (tblUserID.Rows.Count == 1)
                {
                    _dal.DeleteUser(request.UnSubscribe);
                    retval = new UnSubscribeResponseOK(request);
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
