using Microsoft.Playwright;

namespace AssignementPlaywright.PageObjects
{
    public class AssetDetailsPage
    {
        private IPage _page;

        public AssetDetailsPage(IPage page)
        {
            _page = page;
        }

        #region Locators
        private ILocator MacBookLapTopType => _page.Locator("a[href=\"https://demo.snipeitapp.com/models/1\"]:has-text('Macbook Pro 13')");
        private ILocator asssetNumberLocator => _page.Locator(".js-copy-assettag");
        private ILocator serialNumberLocator => _page.Locator(".js-copy-serial");
        private ILocator histroyTabLocator => _page.Locator("a[href='#history']");
        private ILocator historytableAssetColumnLocator => _page.Locator("table tbody tr:nth-child(1) td:nth-child(5)");
        private ILocator historytableActionTypeLocator => _page.Locator("table tbody tr:nth-child(1) td:nth-child(4)");
        #endregion

        public async Task VerifyHistoryOfAsset(string assetNumber, string serialNumber, string assetName)
        {
            await NavigateHistory();
            //await ValidateHistoryTableValues(assetNumber, serialNumber, assetName);
        }

        private async Task NaviagetAssetDetails(string serialNumber)
        {
            var assetDetailsSelector = _page.Locator($"a:has-text(\"{serialNumber}\")");
            await assetDetailsSelector.WaitForAsync();
            await assetDetailsSelector.ClickAsync();
        }
      
        private async Task NavigateHistory()
        {
            await histroyTabLocator.WaitForAsync();
            await histroyTabLocator.ClickAsync();
        }

        public async Task NaviagetAssetDetails(string assetNumber, string serialNumber, string assetName)
        {
            await NaviagetAssetDetails(serialNumber);
        }
       
        public async Task<string> GetAsssetNumberFeildValue() { 
            return await asssetNumberLocator.InnerTextAsync();
        }

        public async Task<string> GetSerialNumberFeildValue()
        {
            return await serialNumberLocator.InnerTextAsync();
        }

        public async Task<string> ValidateActionTypeColumn()
        {
            await historytableActionTypeLocator.WaitForAsync();
            return await historytableActionTypeLocator.InnerTextAsync();
        }

        public async Task<string> ValidateAssetNumberColumn() {

            await historytableAssetColumnLocator.WaitForAsync();
            return await historytableAssetColumnLocator.InnerTextAsync();
        }

        public async Task<bool> ValidateLaptopTypeColumnAsMacBook13()
        {
            return await MacBookLapTopType.IsVisibleAsync();
        }

    }
}
