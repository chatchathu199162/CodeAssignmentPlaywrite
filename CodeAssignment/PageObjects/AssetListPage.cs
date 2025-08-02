using Microsoft.Playwright;

public class AssetListPage
{
    private readonly IPage _page;

    public AssetListPage(IPage page)
    {
        _page = page;
    }

    #region Locators
    private ILocator AssetTile => _page.Locator(".dashboard.small-box.bg-teal:has-text('Asset')");
    private ILocator PageTitle => _page.Locator(".breadcrumb-item.active");
    private ILocator SearchBox => _page.Locator("[placeholder='Search']");
    #endregion

    public async Task ViewAssets(string serialNumber)
    {
        await NavigateToAssetsPageAsync();
        await SearchAssetBySerialAsync(serialNumber);
        await IsSerialNumberInTableAsync(serialNumber);
       
    }
    private async Task NavigateToAssetsPageAsync()
    {
        await AssetTile.ClickAsync();
        await PageTitle.WaitForAsync();
        Assert.IsTrue(await PageTitle.IsVisibleAsync());
    }

    private async Task SearchAssetBySerialAsync(string serialNumber)
    {
        await SearchBox.FillAsync(serialNumber);
        await _page.Keyboard.PressAsync("Enter");

    }

    private async Task IsSerialNumberInTableAsync(string serialNumber)
    {
        var serialLocator = _page.Locator($"a:has-text(\"{serialNumber}\")");
        await serialLocator.WaitForAsync();
        Assert.IsTrue(await serialLocator.IsVisibleAsync());
    }
}
