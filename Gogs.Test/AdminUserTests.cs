using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gogs.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gogs.Test
{
    [TestClass]
    public class AdminUserTests
    {
        [TestMethod]
        public void CreateUserTest()
        {
            //Arrange
            GogsClient client = new GogsClient(TestInfo.HostUrl);
            client.Authenticate(TestInfo.AdminUsername, TestInfo.AdminPassword);
            UserCreateInfo createInfo = new UserCreateInfo()
            {
                Source_Id = 0,
                Username = TestInfo.Username,
                Email = $"{TestInfo.Username}@mydomain.com",
                Password = TestInfo.Password
            };

            //Act
            var user = client.AdminUsers.CreateUser(createInfo);

            //Assert
            Assert.AreNotEqual(0, user.Id);
            Assert.AreEqual(TestInfo.Username, user.Username);
            Assert.AreEqual( $"{TestInfo.Username}@mydomain.com", user.Email);
        }

        [TestMethod]
        public void EditUserTest()
        {
            //Arrange
            GogsClient client = new GogsClient(TestInfo.HostUrl);
            client.Authenticate(TestInfo.AdminUsername, TestInfo.AdminPassword);
            UserEditInfo editInfo = new UserEditInfo()
            {
                Full_Name = "Foo Bar",
                Email = "newemail@mydomain.com"
            };

            //Act
            var user = client.AdminUsers.EditUser(TestInfo.Username, editInfo);

            //Assert
            Assert.AreNotEqual(0, user.Id);
            Assert.AreEqual(TestInfo.Username, user.Username);
            Assert.AreEqual( $"newemail@mydomain.com", user.Email);
            Assert.AreEqual( $"Foo Bar", user.Full_Name);
        }

        [TestMethod]
        public void DeleteUser()
        {
            //Arrange
            GogsClient client = new GogsClient(TestInfo.HostUrl);
            client.Authenticate(TestInfo.AdminUsername, TestInfo.AdminPassword);

            //Act
            var response = client.AdminUsers.DeleteUser(TestInfo.Username);

            //Assert
            Assert.IsTrue(response);
        }
    }
}
