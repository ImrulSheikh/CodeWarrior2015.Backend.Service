using System.Web.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuySellService.Tests
{
    [TestClass]
    public class UserAdminRepositoryTest
    {
       
        
        [TestMethod]
        public void Check_ResetPassword_Test()
        {
                 
            var password = "H@rd";
            var encryptedPassword = FormsAuthentication.HashPasswordForStoringInConfigFile(password, "md5").ToLower();
            Assert.AreEqual("64e799b51ac7717fbf685a4890f3f3ee", encryptedPassword);

        }
    }
}
