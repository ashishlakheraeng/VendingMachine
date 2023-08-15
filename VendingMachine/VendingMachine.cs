using System;

namespace VendingMachineProject
{
    public class VendingMachine
    {
        public VendingMachine()
        {
            CoinSlot = new CoinData();
            CoinReturn = new CoinData();
            CoinBank = new CoinData();
            Inventory = new VendingMachinProduct();
        }
        #region variables
        // where we insert money
        public CoinData CoinSlot { get; private set; }

        // return the coin
        public CoinData CoinReturn { get; private set; }
        public CoinData CoinBank { get; private set; }
        public VendingMachinProduct Inventory { get; private set; }
        private string TemporaryDisplay { get; set; }

        private string ReturnMoney = string.Empty;

        #endregion



        /// <summary>
        /// method is use to dispense the coin from the machine
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public Tuple<string, string> Dispense(MachineProducts product)
        {
            double price = GetPrice(product);

            if (Inventory.Count(product) == 0)
            {
                // The item requsted is out of stock.
                TemporaryDisplay = "SOLD OUT";
            }
            else if (CoinSlot.Value >= price)
            {
                // There's enough money and an item
                // to dispense.
                Inventory.DispenseProduct(product);
                TemporaryDisplay = "THANK YOU";

                double changeDue = CoinSlot.Value - price;
                ReturnMoney = changeDue.ToString();
                if (changeDue > 0)
                {
                    // Put the change in the coin return.
                    // Change comes from the coin bank before
                    CoinBank.DispenseInto(CoinReturn, changeDue);
                }

                // Deposit the money into the coinbank.
                CoinSlot.EmptyInto(CoinBank);
            }
            else
            {
                // If there isn't enough money to pay for an item
                // when they try to dispense, remind the use how much the item costs.
                TemporaryDisplay = "Please insert more coin";
            }
            return new Tuple<string, string>(TemporaryDisplay, ReturnMoney);
        }

        /// <summary>
        /// Return all coins back to the user.
        /// </summary>
        public void ReturnCoins()
        {
            CoinSlot.EmptyInto(CoinReturn);
        }

        /// <summary>
        /// Get price for the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public double GetPrice(MachineProducts product)
        {
            double price = 0;
            if (product == MachineProducts.Cola)
            {
                price = 1;
            }
            else if (product == MachineProducts.Chips)
            {
                price = .50;
            }
            else if (product == MachineProducts.Candy)
            {
                price = .65;
            }
            return price;
        }
        public double ReturnCoinsToUser()
        {
            return CoinReturn.Value;
        }
        // Insert coins into the coin slot.
        public void Insert(Coin coin, int num)
        {
            CoinSlot.AddCoins(coin, num);
        }

        // Add products to the invenory
        public void AddProduct(MachineProducts product, int num)
        {
            Inventory.AddProduct(product, num);
        }

        // Add money he the coin bank. 
        public void AddToBank(Coin coin, int num)
        {
            CoinBank.AddCoins(coin, num);
        }
    }
}
