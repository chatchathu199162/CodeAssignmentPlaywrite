using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace AssignementPlaywright.PageObjects
{
    public class LoginPage
    {
        private readonly IPage _loginPageModel;

        public LoginPage(IPage page)
        {
            _loginPageModel = page;
        }
        private ILocator UserNameInput => _loginPageModel.Locator("[name='username']");
        private ILocator PasswordInput => _loginPageModel.Locator("#password");
        private ILocator LoginButton => _loginPageModel.Locator("button[type='submit']");

        private ILocator SuccessLoginMessage => _loginPageModel.Locator(".pull-left.pagetitle");
        private ILocator FailedLoginMessage => _loginPageModel.Locator(".alert.alert.alert-danger.fade.in");
        public async Task LoginAction(string userName , string password)
        {
            await _loginPageModel.GotoAsync("https://demo.snipeitapp.com/login");
            await UserNameInput.FillAsync(userName);
            await PasswordInput.FillAsync(password);
            await LoginButton.ClickAsync();
            await _loginPageModel.WaitForLoadStateAsync(LoadState.DOMContentLoaded);
        }

        public async Task<bool> IsValidLogin() {
           return await  SuccessLoginMessage.IsVisibleAsync();
        }


        public async Task<bool> IsInValidLogin()
        {
            return await FailedLoginMessage.IsVisibleAsync();
        }

    }
}
