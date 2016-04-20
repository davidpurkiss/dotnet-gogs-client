using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gogs.Test
{
    [TestClass]
    public class AdminReposTests
    {
        [TestMethod]
        public void CreateRepositoryTest()
        {
            //Arrange
            string repoName = "test-repo";
            GogsClient client = new GogsClient(TestInfo.HostUrl);
            client.Authenticate(TestInfo.AdminUsername, TestInfo.AdminPassword);

            //Act
            var repo = client.AdminRepos.CreateRepository(TestInfo.AdminUsername, new Model.RepositoryCreateInfo { Name = repoName });

            //Assert
            Assert.AreEqual($"{TestInfo.AdminUsername}/{repoName}", repo.Full_Name);
        }
    }
}
