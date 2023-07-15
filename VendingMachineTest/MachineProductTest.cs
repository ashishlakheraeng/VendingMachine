using VendingMachineProject;

namespace VendingMachineTest
{
    public class MachineProductTest
    {
        VendingMachine vm;
        [SetUp]
        public void Init()
        {
            vm = new VendingMachine();
        }

        [Test]
        public void ValidateCostOfCola()
        {
            Assert.AreEqual(1, vm.GetPrice(MachineProducts.Cola));
        }

        [Test]
        public void ValidateCostOfChips()
        {
            Assert.AreEqual(.50, vm.GetPrice(MachineProducts.Chips));
        }

        [Test]
        public void ValidateCostOfCandy()
        {
            Assert.AreEqual(.65, vm.GetPrice(MachineProducts.Candy));
        }
    }
}
