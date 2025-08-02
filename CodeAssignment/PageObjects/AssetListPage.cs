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
    private ILocator NoRecordsFound => _page.Locator(".no-records-found");
    
    #endregion

    public async Task ViewAssetsList(string serialNumber)
    {
        await NavigateToAssetsPageAsync();
        await SearchAssetBySerialAsync(serialNumber);
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

    public async Task<bool> IsSerialNumberInTableAsync(string serialNumber)
    {
        var serialLocator = _page.Locator($"a:has-text(\"{serialNumber}\")");
        await serialLocator.WaitForAsync();
        return await serialLocator.IsVisibleAsync();
    }

    public async Task<bool> IsNoRecordFound(string serialNumber)
    {
        await NoRecordsFound.WaitForAsync();
        return await NoRecordsFound.IsVisibleAsync();
    }

    
}
