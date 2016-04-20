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
    public class RepositoryWebHooksTests
    {
        [TestMethod]
        public void ListHooksTest()
        {
            //Arrange
            GogsClient client = new GogsClient(TestInfo.HostUrl);
            client.Authenticate(TestInfo.AdminUsername, TestInfo.AdminPassword);

            //Act
            var webhooks = client.RepositoryWebhooks.ListHooks("test-repo");

            //Assert
            Assert.AreEqual(0, webhooks.Count());
        }

        [TestMethod]
        public void CreateHookTest()
        {
            //Arrange
            GogsClient client = new GogsClient(TestInfo.HostUrl);
            client.Authenticate(TestInfo.AdminUsername, TestInfo.AdminPassword);
            RepositoryWebhook webhookInfo = new RepositoryWebhook()
            {
                Type = "gogs",
                Events = new string[] { "create", "push" },
                Active = true
            };

            webhookInfo.Config["url"] = "http://test";

            //Act
            var webhook = client.RepositoryWebhooks.CreateHook(webhookInfo, "test-repo");

            //Assert
            Assert.AreNotEqual(0, webhook.Id);
            Assert.AreEqual("http://test", webhook.Config["url"]);
        }

        [TestMethod]
        public void EditHookTest()
        {
             //Arrange
            GogsClient client = new GogsClient(TestInfo.HostUrl);
            client.Authenticate(TestInfo.AdminUsername, TestInfo.AdminPassword);
            RepositoryWebhook webhookInfo = new RepositoryWebhook()
            {
                Id = 2,
                Type = "gogs",
                Events = new string[] { "push" },
                Active = false
            };

            webhookInfo.Config["url"] = "http://test";

            //Act
            var webhook = client.RepositoryWebhooks.EditHook(webhookInfo, "test-repo");

            //Assert
            //Assert.AreNotEqual(0, webhook.Id);
            Assert.AreEqual("http://test", webhook.Config["url"]);
        }
    }
}
