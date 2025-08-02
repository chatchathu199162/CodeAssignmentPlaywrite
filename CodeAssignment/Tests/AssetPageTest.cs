

namespace AssignementPlaywright.Tests
{
    public class AssetPageTest : PlaywriteTestBaseSetUp
    {
        [Test]
        public async Task CreateAssetTest()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            Assert.IsTrue(await assetPage.IsSuccessFullyCreateAsset());
        }

        [Test]
        public async Task ViewAssetInListTest()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            await assetList.ViewAssets(_serialNumber);
        }
    }
}