namespace AssignementPlaywright.Tests
{
    public class LoginPageTest : PlaywriteTestBaseSetUp
    {
        private string invalidUser = "INVALIDUSER";
        private string invalidPassword = "INVALIDPPASSWORD";

        [Test]
        public async Task ValidateLogin_ValidCredentials_success()
        {
            await loginPage.LoginAction(_userName, _password);
            Assert.IsTrue(await loginPage.IsValidLogin());
        }

        [Test]
        public async Task ValidateLogin_InValidCredentials_Fail()
        {
            await loginPage.LoginAction(invalidUser, invalidPassword);
            
            Assert.IsFalse(await loginPage.IsValidLogin());
            Assert.IsTrue(await loginPage.IsInValidLogin());
        }


    }
}