using System;
using ORPZ_lab5.Entities;

namespace ORPZ_lab5.Factories
{
    public class UsdFactory : IAbstractFactory
    {
        public Coin MakeCoin(int value)
        {
            if (value < 1 || value > 100)
                throw new Exception("The coin value must be less than 100 and greater than 1.");

            return new Coin { Currency = "USD", Value = value };
        }

        public Banknote MakeBanknote(int value)
        {
            if (value < 1)
                throw new Exception("The banknote value can't be less than 1.");

            return new Banknote { Currency = "USD", Value = value };
        }
    }
}