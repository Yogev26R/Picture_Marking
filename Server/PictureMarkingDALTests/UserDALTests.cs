using NUnit.Framework;
using PictureMarkingContracts.DTO.User;
using PictureMarkingDAL;

namespace PictureMarkingDALTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestCreateUser()
        {
            var contactListDAL = new UserDALImpl();
            var register = new RegisterDTO
            {
                Login = new LoginDTO { UserName = "Yogev26R" },
                UserID = "yogev26r@gmail.com"
            };
            var ds = contactListDAL.CreateUser(register);
            var tbl = ds.Tables[0];
            Assert.AreEqual((string)tbl.Rows[0][0], register.UserID);
        }

        [Test]
        public void TestReadUserUserNotExists()
        {
            var contactListDAL = new UserDALImpl();
            var ds = contactListDAL.ReadUserByUserID("notExist");
            Assert.AreEqual(ds.Tables[0].Rows.Count, 0);
        }

        [Test]
        public void TestGetUserUserExists()
        {
            var contactListDAL = new UserDALImpl();
            var ds = contactListDAL.ReadUserByUserID("Yogev26R");
            Assert.AreEqual(1, ds.Tables[0].Rows.Count);
        }
    }
}