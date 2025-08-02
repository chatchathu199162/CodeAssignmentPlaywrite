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
        private ILocator AsssetNumberLocator => _page.Locator(".js-copy-assettag");
        private ILocator SerialNumberLocator => _page.Locator(".js-copy-serial");
        private ILocator HistroyTabLocator => _page.Locator("a[href='#history']");
        private ILocator HistorytableAssetColumnLocator => _page.Locator("table tbody tr:nth-child(1) td:nth-child(5)");
        private ILocator HistorytableActionTypeLocator => _page.Locator("table tbody tr:nth-child(1) td:nth-child(4)");
        #endregion

        private async Task NaviagetAssetDetails(string serialNumber)
        {
            var assetDetailsSelector = _page.Locator($"a:has-text(\"{serialNumber}\")");
            await assetDetailsSelector.WaitForAsync();
            await assetDetailsSelector.ClickAsync();
        }
      
        public async Task NavigateHistoryTab()
        {
            await HistroyTabLocator.WaitForAsync();
            await HistroyTabLocator.ClickAsync();
        }

        public async Task NaviagetAssetDetails(string assetNumber, string serialNumber, string assetName)
        {
            await NaviagetAssetDetails(serialNumber);
        }
       
        public async Task<string> GetAsssetNumberFeildValue() { 
            return await AsssetNumberLocator.InnerTextAsync();
        }

        public async Task<string> GetSerialNumberFeildValue()
        {
            return await SerialNumberLocator.InnerTextAsync();
        }

        public async Task<string> ValidateActionTypeColumn()
        {
            await HistorytableActionTypeLocator.WaitForAsync();
            return await HistorytableActionTypeLocator.InnerTextAsync();
        }

        public async Task<string> ValidateAssetNumberColumn() {

            await HistorytableAssetColumnLocator.WaitForAsync();
            return await HistorytableAssetColumnLocator.InnerTextAsync();
        }

        public async Task<bool> ValidateLaptopTypeColumnAsMacBook13()
        {
            return await MacBookLapTopType.IsVisibleAsync();
        }

    }
}
