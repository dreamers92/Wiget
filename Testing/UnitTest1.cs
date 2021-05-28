using AcmeWidget.Models;
using AcmeWidget.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EmailCategory_EmailIsYahoo_Returns1()
        {

            //Arrange
            var emailManager = new EmailManager();

            //Act
            var result = emailManager.EmailCategoty(new EmailManager { EmailAddress = "test@yahoo.com" });

            //Assert
            Assert.IsTrue(result == 2);
        }

        [TestMethod]
        public void EmailCategory_EmailIsGmail_Returns3()
        {

            //Arrange
            var emailManager = new EmailManager();

            //Act
            var result = emailManager.EmailCategoty(new EmailManager { EmailAddress = "test@gmail.com" });

            //Assert
            Assert.IsTrue(result == 3);
        }
    }
}
