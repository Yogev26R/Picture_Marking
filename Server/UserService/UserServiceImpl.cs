using Contracts;
using Contracts.DTO;
using PictureMarkingContracts.DTO;
using PictureMarkingContracts.DTO.User;
using PictureMarkingContracts.Interface;
using System;

namespace UserService
{
    [Register(Policy.Transient, typeof(IUserService))]
    public class UserServiceImpl : IUserService
    {
        IPictureMarkingDAL _dal;

        public UserServiceImpl(IPictureMarkingDAL dal)
        {
            _dal = dal;
        }

        public Response UnSubscribe(UnSubscribeRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
