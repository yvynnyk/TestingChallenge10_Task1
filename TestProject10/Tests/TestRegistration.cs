using NUnit.Framework;
using TestProject10.Framework;
using TestProject10.Pages;

namespace TestProject10.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
           
        [TestCaseSource(typeof(User), nameof(User.GetUsersFromCSVFile))]
        public void TestRegistration(User user)
        {           
            Logger.Info($"Registration of user {user.Name} started");
            
            registrationPage.RegisterUser(user.Name, user.Password, user.FirstName, user.LastName);
            
            Logger.Info($"Check if {user.Name} appears in DB");
            
            Assert.Multiple(() =>
            {
                Assert.That(user.Name, Is.EqualTo(registrationPage.GetNameFromTable()), $"Name in the table is not equal to the registered name: ${user.Name}");
                Assert.That(user.Password, Is.EqualTo(registrationPage.GetPasswordFromTable()), $"Password in the table is not equal to the registered password: ${user.Password}");
                Assert.That(user.FirstName, Is.EqualTo(registrationPage.GetFirstNameFromTable()), $"First name in the table is not equal to the registered first name: ${user.FirstName}");
                Assert.That(user.LastName, Is.EqualTo(registrationPage.GetLastNameFromTable()), $"Last name in the table is not equal to the registered name: ${user.LastName}");
            });

            Logger.Info($"Logging of user {user.Name} started");

            PageHome homePage = SiteNavigator.NavigateToLoginPage(Driver, registrationPage.ApplicationLink).Login(user.Name, user.Password);

            Assert.That("Wellcome To Your Personal Road Assitance", Is.EqualTo(homePage.GetHeader()), "Login was not successful. Main page was not displayed");            
        }
    }
}
        
     