using Microsoft.Playwright;

namespace AssignementPlaywright.PageObjects
{
    public class LoginPage
    {
        private readonly IPage _loginPageModel;

        public LoginPage(IPage page)
        {
            _loginPageModel = page;
        }
        public async Task LoginAction(string userName , string password)
        {
            await _loginPageModel.GotoAsync("https://demo.snipeitapp.com/login");
            await _loginPageModel.FillAsync("[name='username']", userName);
            await _loginPageModel.FillAsync("#password", password);
            await _loginPageModel.ClickAsync("button[type='submit']");
            await _loginPageModel.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }
    }
}
