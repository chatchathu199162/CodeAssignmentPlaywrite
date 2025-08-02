namespace AssignementPlaywright.Tests
{
    public class LoginPageTest : PlaywriteTestBaseSetUp
    {

        [Test]
        public async Task ValidateLogin()
        {
            await loginPage.LoginAction(_userName, _password);
        }

    }
}