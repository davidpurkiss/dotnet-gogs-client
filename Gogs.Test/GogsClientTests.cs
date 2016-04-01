using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gogs.Test
{
    [TestClass]
    public class GogsClientTests
    {
        [TestMethod]
        public void AuthenticateTest()
        {
            //Arrange
            GogsClient client = new GogsClient(TestInfo.HostUrl);

            //Act
            string token = client.Authenticate(TestInfo.AdminUsername, TestInfo.AdminPassword);

            //Assert
            Assert.IsNotNull(token);
            Assert.AreEqual(token, client.AccessToken);
        }
    }
}
