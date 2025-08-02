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
        private ILocator modelLocator => _page.Locator("a[href=\"https://demo.snipeitapp.com/models/1\"]:has-text('Macbook Pro 13')");
        private ILocator asssetNumberLocator => _page.Locator(".js-copy-assettag");
        private ILocator serialNumberLocator => _page.Locator(".js-copy-serial");
        private ILocator histroyTabLocator => _page.Locator("a[href='#history']");
        private ILocator historytableAssetColumnLocator => _page.Locator("table tbody tr:nth-child(1) td:nth-child(5)");
        private ILocator historytableActionTypeLocator => _page.Locator("table tbody tr:nth-child(1) td:nth-child(4)");
        #endregion

        public async Task VerifyHistoryOfAsset(string assetNumber, string serialNumber, string assetName)
        {
            await NavigateHistory();
            await ValidateHistoryTableValues(assetNumber, serialNumber, assetName);
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

        public async Task VerifyDetailsOfAsset(string assetNumber, string serialNumber, string assetName)
        {
            await NaviagetAssetDetails(serialNumber);
            await VerifyHistorysOfAsset(assetNumber, serialNumber);

        }
        private async Task VerifyHistorysOfAsset(string assetNumber, string serialNumber)
        {
            string assetNumberFeildValue = await asssetNumberLocator.InnerTextAsync();
            Assert.IsTrue(assetNumberFeildValue == assetNumber);

            string serialNumberFeildValue = await serialNumberLocator.InnerTextAsync();
            Assert.IsTrue(serialNumberFeildValue == serialNumber);

            bool IsModelVisible = await modelLocator.IsVisibleAsync();
            Assert.IsTrue(IsModelVisible);
        }

        private async Task ValidateHistoryTableValues(string assetNumber, string serialNumber, string assetName)
        {
            
            await historytableAssetColumnLocator.WaitForAsync();
            string assetNumberLocatorValue = await historytableAssetColumnLocator.InnerTextAsync();
            Assert.IsTrue(assetNumberLocatorValue.Contains(assetNumber));
            Assert.IsTrue(assetNumberLocatorValue.Contains(assetName));

            await historytableActionTypeLocator.WaitForAsync();
            string actionValue = await historytableActionTypeLocator.InnerTextAsync();
            Assert.IsTrue(actionValue == "create new");
        }

    }
}
