
using AssignementPlaywright.PageObjects;
using System.Security.Cryptography.X509Certificates;

namespace AssignementPlaywright.Tests
{
    internal class AssetDetailsPageTest: PlaywriteTestBaseSetUp
    {
        [Test]
        public async Task VerifyAssetDetailsTest()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            await assetList.ViewAssetsList(_serialNumber);
            await assetDetails.NaviagetAssetDetails(_assetNumber, _serialNumber, _assetName);

            string assetNumberFieldValue = await assetDetails.GetAsssetNumberFeildValue();
            string serialNumberFieldValue = await assetDetails.GetSerialNumberFeildValue();
            bool isMackbookproType = await assetDetails.ValidateLaptopTypeColumnAsMacBook13();

            Assert.IsTrue(assetNumberFieldValue == _assetNumber);
            Assert.IsTrue(serialNumberFieldValue == _serialNumber);
            Assert.IsTrue(isMackbookproType);
        }

        [Test]
        public async Task VerifyAssetHistoryTest()
        {
            await loginPage.LoginAction(_userName, _password);
            await assetPage.CreateNewAsset(_assetName, _assetNumber, _serialNumber);
            await assetList.ViewAssetsList(_serialNumber);
            await assetDetails.NaviagetAssetDetails(_assetNumber, _serialNumber, _assetName);
            await assetDetails.VerifyHistoryOfAsset(_assetNumber, _serialNumber, "Macbook");

            string assetNumberlNumberColumn = await assetDetails.ValidateAssetNumberColumn();
            string itemCreateStatus = await assetDetails.ValidateActionTypeColumn();

            Assert.IsTrue(assetNumberlNumberColumn.Contains(_assetNumber));
            Assert.IsTrue(assetNumberlNumberColumn.Contains("Macbook"));
            Assert.IsTrue(itemCreateStatus == "create new");
        }





    }
}
