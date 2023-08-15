using System;
using System.Collections.Generic;

namespace VendingMachineProject
{
    public class CoinData
    {
        private Dictionary<Coin, double> Coins { get; set; }
        public CoinData() { Coins = new Dictionary<Coin, double>(); }

        public double Value
        {
            get
            {
                return
                    CalculateNumberOfCoin(Coin.Quarters) * CalculateCoinValue(Coin.Quarters) +
                    CalculateNumberOfCoin(Coin.Dimes) * CalculateCoinValue(Coin.Dimes) +
                    CalculateNumberOfCoin(Coin.Nickels) * CalculateCoinValue(Coin.Nickels);
            }
        }

        /// <summary>
        /// valuation of different different coins
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="amount"></param>
        internal void DispenseInto(CoinData collection, double amount)
        {
            // Use a cascading subtraction system, like you're taught in 
            // retail for counting change.
            double numQuartersDispensed = DispenseCoinInto(collection, Coin.Quarters, amount);
            amount -= numQuartersDispensed * CalculateCoinValue(Coin.Quarters);

            double numDimesDispensed = DispenseCoinInto(collection, Coin.Dimes, amount);
            amount -= numDimesDispensed * CalculateCoinValue(Coin.Dimes);

            double numNickelsDispensed = DispenseCoinInto(collection, Coin.Nickels, amount);
            amount -= numNickelsDispensed * CalculateCoinValue(Coin.Nickels);

        }

        /// <summary>
        /// calculate total number of dispensed coin
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="coin"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        private double DispenseCoinInto(CoinData collection, Coin coin, double amount)
        {
            double numDispensed = Math.Min(amount / CalculateCoinValue(coin), CalculateNumberOfCoin(coin));
            collection.AddCoins(coin, numDispensed);
            RemoveCoins(coin, numDispensed);
            return numDispensed;
        }

        internal void EmptyInto(CoinData collection)
        {
            foreach (var kvp in Coins)
            {
                collection.AddCoins(kvp.Key, kvp.Value);
            }
            Coins.Clear();
        }

        /// <summary>
        /// Add coins into the mcahine
        /// </summary>
        /// <param name="InsertedCoin"></param>
        /// <param name="number"></param>
        internal void AddCoins(Coin InsertedCoin, double number)
        {
            if (Coins.ContainsKey(InsertedCoin))
                Coins[InsertedCoin] += number;
            else
                Coins.Add(InsertedCoin, number);
        }

        /// <summary>
        /// remove coins from machine
        /// </summary>
        /// <param name="coin"></param>
        /// <param name="num"></param>
        private void RemoveCoins(Coin coin, double num)
        {
            if (Coins.ContainsKey(coin))
            {
                Coins[coin] -= Math.Min(num, Coins[coin]);
            }
        }

        /// <summary>
        /// Calculated value of each coin
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        private double CalculateCoinValue(Coin coin)
        {
            double value = 0;
            if (coin == Coin.Nickels)
                value = .05;
            else if (coin == Coin.Dimes)
                value = .1;
            else if (coin == Coin.Quarters)
                value = .25;

            return value;
        }

        /// <summary>
        /// calculate number of coins in machine
        /// </summary>
        /// <param name="coin"></param>
        /// <returns></returns>
        public double CalculateNumberOfCoin(Coin coin)
        {
            double count = 0;
            if (Coins.ContainsKey(coin))
            {
                count = Coins[coin];
            }

            return count;
        }

    }
}
