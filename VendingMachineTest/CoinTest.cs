using VendingMachineProject;

namespace VendingMachineTest
{
    public class CoinTest
    {

        VendingMachine vendingMachine;

        [SetUp]
        public void Init()
        {
            vendingMachine = new VendingMachine();
        }

        [Test]
        public void CkeckQuartersValue()
        {
            vendingMachine.Insert(Coin.Quarters, 1);
            Assert.AreEqual(.25, vendingMachine.CoinSlot.Value);
        }

        [Test]
        public void CheckDimesValue()
        {
            vendingMachine.Insert(Coin.Dimes, 1);
            Assert.AreEqual(.1, vendingMachine.CoinSlot.Value);
        }

        [Test]
        public void CheckNickelsValue()
        {
            vendingMachine.Insert(Coin.Nickels, 1);
            Assert.AreEqual(.05, vendingMachine.CoinSlot.Value);
        }

        [Test]
        public void CheckEmptyCoin()
        {
            Assert.AreEqual(0, vendingMachine.CoinSlot.Value);
        }

        [Test]
        public void CalculateCostOfCoin()
        {
            vendingMachine.Insert(Coin.Quarters, 1);
            vendingMachine.Insert(Coin.Nickels, 1);
            vendingMachine.Insert(Coin.Dimes, 1);
            Assert.AreEqual(.40, Math.Round(vendingMachine.CoinSlot.Value, 2));
        }

        [Test]
        public void CalculateNumberOfCoin()
        {
            vendingMachine.AddProduct(MachineProducts.Chips, 10);
            vendingMachine.Insert(Coin.Nickels, 1);
            vendingMachine.Insert(Coin.Quarters, 2);
            vendingMachine.Dispense(MachineProducts.Chips);
            Assert.AreEqual(2, vendingMachine.CoinBank.CalculateNumberOfCoin(Coin.Quarters));
        }
    }
}