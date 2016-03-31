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
            GogsClient client = new GogsClient("http://localhost");

            client.Authenticate("david", "riD4ETwc!");

            var repo = client.AdminRepos.CreateRepository("david", "testrepo");
        }
    }
}
