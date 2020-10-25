using PictureMarkingContracts.DTO.User;
using System.Data;

namespace PictureMarkingContracts.Interface
{
    public interface IUserDAL
    {
        public DataSet CreateUser(RegisterDTO register);

        public DataSet ReadUserByUserID(string userID);

        public DataSet ReadUserByUserName(string userName);

        public DataSet UpdateUser(string userName);

        public DataSet DeleteUser(UnSubscribeDTO userName);
    }
}
