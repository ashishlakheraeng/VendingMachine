using VendingMachineProject;

namespace VendingMachineTest
{
    public class CoinTest
    {

        VendingMachine vm;

        [SetUp]
        public void Init()
        {
            vm = new VendingMachine();
        }

        [Test]
        public void CkeckQuartersValue()
        {
            vm.Insert(Coin.Quarters, 1);
            Assert.AreEqual(.25, vm.CoinSlot.Value);
        }

        [Test]
        public void CheckDimesValue()
        {
            vm.Insert(Coin.Dimes, 1);
            Assert.AreEqual(.1, vm.CoinSlot.Value);
        }

        [Test]
        public void CheckNickelsValue()
        {
            vm.Insert(Coin.Nickels, 1);
            Assert.AreEqual(.05, vm.CoinSlot.Value);
        }

        [Test]
        public void CheckEmptyCoin()
        {
            Assert.AreEqual(0, vm.CoinSlot.Value);
        }

        [Test]
        public void CalculateCostOfCoin()
        {
            vm.Insert(Coin.Quarters, 1);
            vm.Insert(Coin.Nickels, 1);
            vm.Insert(Coin.Dimes, 1);
            Assert.AreEqual(.40, Math.Round(vm.CoinSlot.Value, 2));
        }

        [Test]
        public void CalculateNumberOfCoin()
        {
            vm.AddProduct(MachineProducts.Chips, 10);
            vm.Insert(Coin.Nickels, 1);
            vm.Insert(Coin.Quarters, 2);
            vm.Dispense(MachineProducts.Chips);
            Assert.AreEqual(2, vm.CoinBank.CalculateNumberOfCoin(Coin.Quarters));
        }
    }
}