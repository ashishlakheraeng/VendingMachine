using System;

namespace VendingMachineProject
{
    internal class Program
    {
        private static VendingMachine _vendingMachine = new VendingMachine();

        static void Main(string[] args)
        {
            AddStaticDataInVendorMachine();
            TakeProductInput();
            Console.ReadKey();
        }
        private static void TakeProductInput()
        {
        Start:
            Console.WriteLine("choose one item by entering the number");
            Console.WriteLine("For Exit press 112");
            Console.WriteLine((int)MachineProducts.Cola + " " + MachineProducts.Cola);
            Console.WriteLine((int)MachineProducts.Chips + " " + MachineProducts.Chips);
            Console.WriteLine((int)MachineProducts.Candy + " " + MachineProducts.Candy);
            string enteredNumber = Console.ReadLine();
            int.TryParse(enteredNumber, out int number);
            if (number == 112)
            {
                Exit();
            }
            if (number == 1 || number == 2 || number == 3)
            {
                int chooseProduct = number;
            addMoreCoin:
                Console.WriteLine("Cost of " + (MachineProducts)chooseProduct + " = " + _vendingMachine.GetPrice((MachineProducts)chooseProduct) + "$");
                TakeCointInput();
                var returnData = _vendingMachine.Dispense((MachineProducts)chooseProduct);
                Console.WriteLine(returnData.Item1);
                if (returnData.Item1 == "Please insert more coin")
                {
                    goto addMoreCoin;
                }
                Console.WriteLine("Collect your Amount:-" + returnData.Item2);
                Console.WriteLine("If you want more item press 1");
                string inputContinue = Console.ReadLine();
                int.TryParse(inputContinue, out int continueProcess);
                if (continueProcess == 112)
                {
                    Exit();
                }
                if (continueProcess == 1)
                    goto Start;

            }
            else
            {
                Console.WriteLine("enter the given option only");
                TakeProductInput();
            }
        }

        private static void TakeCointInput()
        {
            Console.WriteLine("please insert the below coins only");
            Console.WriteLine((int)Coin.Nickels + " " + Coin.Nickels);
            Console.WriteLine((int)Coin.Dimes + " " + Coin.Dimes);
            Console.WriteLine((int)Coin.Quarters + " " + Coin.Quarters);
            string enteredNumber = Console.ReadLine();
            int.TryParse(enteredNumber, out int number);

            if (number == 112)
            {
                Exit();
            }
            if (number == 1 || number == 2 || number == 3)
            {
            enterNumberOfCoin:
                Console.WriteLine("Enter number of coin:-");
                string NumberOfCoin = Console.ReadLine();
                int.TryParse(NumberOfCoin, out int CoinCount);
                if (CoinCount > 0)
                {
                    _vendingMachine.Insert((Coin)number, CoinCount);
                }
                else
                {
                    Console.WriteLine("Please enter correct number only");
                    goto enterNumberOfCoin;
                }
            }
            else
            {
                Console.WriteLine("enter the given option of coin only");
                TakeCointInput();
            }
        }

        private static void Exit()
        {
            _vendingMachine.ReturnCoins();
            Console.WriteLine("Collect your coins:- " + _vendingMachine.ReturnCoinsToUser());
            Console.ReadLine();
            Environment.Exit(0);
        }
        private static void AddStaticDataInVendorMachine()
        {
            _vendingMachine.AddToBank(Coin.Nickels, 10);
            _vendingMachine.AddToBank(Coin.Quarters, 10);
            _vendingMachine.AddToBank(Coin.Dimes, 10);
            _vendingMachine.AddProduct(MachineProducts.Candy, 10);
            _vendingMachine.AddProduct(MachineProducts.Cola, 10);
            _vendingMachine.AddProduct(MachineProducts.Chips, 10);
        }
    }
}
