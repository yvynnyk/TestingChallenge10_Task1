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
                Assert.That(user.Name, Is.EqualTo(registrationPage.GetNameFromTable()));
                Assert.That(user.Password, Is.EqualTo(registrationPage.GetPasswordFromTable()));
                Assert.That(user.FirstName, Is.EqualTo(registrationPage.GetFirstNameFromTable()));
                Assert.That(user.LastName, Is.EqualTo(registrationPage.GetLastNameFromTable()));
            });

            Logger.Info($"Logging of user {user.Name} started");

            //PageHome homePage = registrationPage.GoToLoginPage().Login(user.Name, user.Password);
            PageHome homePage = SiteNavigator.NavigateToLoginPage(Driver, registrationPage.ApplicationLink).Login(user.Name, user.Password);

            Assert.That("Wellcome To Your Personal Road Assitance", Is.EqualTo(homePage.GetHeader()));            
        }
    }
}
        
     