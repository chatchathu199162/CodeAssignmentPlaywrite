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
        public async Task NavigateToAssets()
        {
            await _page.ClickAsync(".dropdown - toggle[tabindex = '-1']");
        }

        public async Task CreateNewAsset(string assetName,string AssetNumber , string serialNumber)
        {
            await _page.ClickAsync(".dropdown-toggle[tabindex='-1']");
            await _page.ClickAsync("a[href='https://demo.snipeitapp.com/hardware/create']");

            await _page.ClickAsync("#select2-company_select-container");
            
            //Select company
            await _page.WaitForSelectorAsync("#select2-company_select-results");
            await _page.ClickAsync(".select2-results__option:first-child");

            //Fill AssetNumber and serial number
            await _page.FillAsync("#asset_tag", AssetNumber);
            await _page.FillAsync("[id = 'serials[1]']", serialNumber);

            //select modle
            await _page.ClickAsync("#select2-model_select_id-container");
            await _page.WaitForSelectorAsync("#select2-model_select_id-results");
            await _page.ClickAsync("li.select2-results__option:has-text('Laptops - Macbook pro 13')");

            //select deploy type
            await _page.ClickAsync("#select2-status_select_id-container");
            await _page.ClickAsync("li.select2-results__option:has-text('Ready to deploy')");

            await _page.ClickAsync(".btn.btn-default.active");

            //select User
            await _page.ClickAsync("#select2-assigned_user_select-container");
            await _page.ClickAsync(".select2-results__option:first-child");
            await _page.FillAsync("#notes", "This is brand new laptop");

            //Select location
            await _page.ClickAsync("#select2-rtd_location_id_location_select-container");
            await _page.ClickAsync(".select2-results__option:first-child");

            //Check requstable checkbox
            await _page.CheckAsync("#requestable");
          
            await _page.ClickAsync("#submit_button");
        }
    }
}
