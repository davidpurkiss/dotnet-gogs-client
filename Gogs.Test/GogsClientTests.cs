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
            GogsClient client = new GogsClient("http://localhost");

            string token = client.Authenticate("david", "riD4ETwc!");

            Assert.IsNotNull(token);
            Assert.AreEqual(token, client.AccessToken);
        }
    }
}
