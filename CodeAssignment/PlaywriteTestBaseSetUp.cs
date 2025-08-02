using AssignementPlaywright.PageObjects;
using AssignementPlaywright.Utility;
using Microsoft.Playwright;

namespace AssignementPlaywright
{
    public class PlaywriteTestBaseSetUp
    {
        private IBrowser _browser { get; set; } = default!;
        private IBrowserContext _browserContext { get; set; } = default!;
        public IPage _page { get; set; } = default!;
        private IPlaywright _playwriteObject { get; set; } = default!;

        public  string _assetName = "Macbook Pro 2023";
        public string _userName = "admin";
        public string _password = "password";


        public LoginPage loginPage;
        public AssetPage assetPage;
        public AssetListPage assetList;
        public AssetDetailsPage assetDetails;
        public string _serialNumber;
        public string _assetNumber;

        [SetUp]
        public async Task Setup()
        {
            _playwriteObject = await Playwright.CreateAsync();
            _browser = await _playwriteObject.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            _browserContext = await _browser.NewContextAsync();
            _page = await _browser.NewPageAsync();
            _serialNumber = SerialNumberRandomgenerator.GeneratSerialNumber();
            _assetNumber = SerialNumberRandomgenerator.GeneratSerialNumber();

            InitalizeObject();
        }

        public void InitalizeObject()
        {
            loginPage = new LoginPage(_page);
            assetPage = new AssetPage(_page);
            assetList = new AssetListPage(_page);
            assetDetails = new AssetDetailsPage(_page);
        }

        [TearDown]
        public async Task TearDown()
        {
            await _browserContext.CloseAsync();
            await _browser.CloseAsync();
            _playwriteObject.Dispose();
        }
    }
}
