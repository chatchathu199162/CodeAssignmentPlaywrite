

namespace AssignementPlaywright.Tests
{
    public class AssetPageTest : PlaywriteTestBaseSetUp
    {
        private string NonSavedSerialNumber = "11111";
        [Test]
        public async Task CreateAsset_FillAllRequireds_Success()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            Assert.IsTrue(await assetPage.IsSuccessFullyCreateAsset());
        }

        [Test]
        public async Task ViewAssetInListTest_ShouldBeIntheAssetList_Success()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            await assetList.ViewAssetsList(_serialNumber);

            Assert.IsTrue(await assetList.IsSerialNumberInTableAsync(_serialNumber));
        }

        [Test]
        public async Task ViewAssetInListTest_ShouldNotBeIntheAssetList_Failed()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            await assetList.ViewAssetsList(NonSavedSerialNumber);

            Assert.IsTrue(await assetList.IsNoRecordFound(NonSavedSerialNumber));
        }
    }
}