using Microsoft.Playwright;

namespace AssignementPlaywright.PageObjects
{
    public class AssetPage
    {
        public IPage _page;
        public AssetPage(IPage assertPage)
        {
            _page = assertPage;
        }

        #region Locators
        private ILocator CreateButton => _page.Locator(".dropdown-toggle[tabindex='-1']");
        private ILocator CreateAssetOption => _page.Locator("a[href='https://demo.snipeitapp.com/hardware/create']");
        private ILocator CompanySelectBox => _page.Locator("#select2-company_select-container");
        private ILocator CompanySelectBoxFirstOption => _page.Locator(".select2-results__option:first-child");
        private ILocator AssetNumberTextFeild => _page.Locator("#asset_tag");
        private ILocator SerialNumberTextFeild => _page.Locator("[id='serials[1]']");
        private ILocator ModelSelectBox => _page.Locator("#select2-model_select_id-container");
        private ILocator ModelMacbookOption => _page.Locator("li.select2-results__option:has-text('Laptops - Macbook pro 13')");
        private ILocator StatusSelectBox => _page.Locator("#select2-status_select_id-container");
        private ILocator ReadyToDeployOption => _page.Locator("li.select2-results__option:has-text('Ready to deploy')");
        private ILocator UserSelectBox => _page.Locator("#select2-assigned_user_select-container");
        private ILocator FirstUserOption => _page.Locator(".select2-results__option:first-child");
        private ILocator NoteTextArea => _page.Locator("#notes");
        private ILocator LocationSelectBox => _page.Locator("#select2-rtd_location_id_location_select-container");
        private ILocator FirstLocationOption => _page.Locator(".select2-results__option:first-child");
        private ILocator RequesterCheckBox => _page.Locator("#requestable");
        private ILocator SubmitButton => _page.Locator("#submit_button");
        private ILocator DashbordViewAllBox => _page.Locator(".dashboard.small-box.bg-teal");

        #endregion

        #region Selectors
        private const string CompanyResultsSelector = "#select2-company_select-results";
        private const string ModelResultsSelector = "#select2-model_select_id-results";
        #endregion 

        public async Task NavigateToAssets()
        {
            await CreateButton.ClickAsync();
            await CreateAssetOption.ClickAsync();

        }

        public async Task CreateNewAsset(string assetName,string AssetNumber , string serialNumber)
        {
            await NavigateToAssets();
            await CompanySelectBox.ClickAsync();
            
            //Select company
            await _page.WaitForSelectorAsync(CompanyResultsSelector);
            await CompanySelectBoxFirstOption.ClickAsync();

            //Fill AssetNumber and serial number
            await AssetNumberTextFeild.FillAsync(AssetNumber);
            await SerialNumberTextFeild.FillAsync(serialNumber);

            //select modle
            await ModelSelectBox.ClickAsync();
            await _page.WaitForSelectorAsync(ModelResultsSelector);
            await ModelMacbookOption.ClickAsync();

            //select deploy type
            await StatusSelectBox.ClickAsync();
            await ReadyToDeployOption.ClickAsync();

            await _page.ClickAsync(".btn.btn-default.active");

            //select User
            await UserSelectBox.ClickAsync();
            await FirstUserOption.ClickAsync();

            await NoteTextArea.FillAsync("This is brand new laptop");

            //Select location
            await LocationSelectBox.ClickAsync();
            await FirstLocationOption.ClickAsync();

            //Check requstable checkbox
            await RequesterCheckBox.CheckAsync();
          
            await SubmitButton.ClickAsync();
        }

        public async Task<bool> IsSuccessFullyCreateAsset()
        {
            return await DashbordViewAllBox.IsVisibleAsync();
        }
    }
}
