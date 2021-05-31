using NUnit.Framework;
using TestProject10.Framework;

namespace TestProject10.Tests
{
    [TestFixture]
    public class Tests : TestBase
    {
        [TestCaseSource(typeof(User), nameof(User.GetUsersFromCSVFile))]
        public void TestRegistration(string userInfo)
        {
            var userCredentials = userInfo.Split(",");
            var userName = userCredentials[0];
            var userPassword = userCredentials[1];
            var userFirstName = userCredentials[2];
            var userLastName = userCredentials[3];

            Logger.Info($"Registration of user {userName} started");

            registrationPage.RegisterUser(userName, userPassword, userFirstName, userLastName);
            
            Logger.Info($"Check if {userName} appears in DB");
            
            Assert.Multiple(() =>
            {
                Assert.That(userName, Is.EqualTo(registrationPage.GetNameFromTable()));
                Assert.That(userPassword, Is.EqualTo(registrationPage.GetPasswordFromTable()));
                Assert.That(userFirstName, Is.EqualTo(registrationPage.GetFirstNameFromTable()));
                Assert.That(userLastName, Is.EqualTo(registrationPage.GetLastNameFromTable()));
            });
        }

    }
}
        
     