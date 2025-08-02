
namespace AssignementPlaywright.Tests
{
    internal class AssetDetailsPageTest: PlaywriteTestBaseSetUp
    {
        [Test]
        public async Task VerifyAssetDetailsTest()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            await assetList.ViewAssets(_serialNumber);
            await assetDetails.VerifyDetailsOfAsset(_assetNumber, _serialNumber, _assetName);
        }

        [Test]
        public async Task VerifyAssetHistoryTest()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            await assetList.ViewAssets(_serialNumber);
            await assetDetails.VerifyDetailsOfAsset(_assetNumber, _serialNumber, _assetName);
            await assetDetails.VerifyHistoryOfAsset(_assetNumber, _serialNumber, "Macbook");
        }





    }
}
