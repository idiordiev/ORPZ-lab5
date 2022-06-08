using ORPZ_lab5.Entities;

namespace ORPZ_lab5.Factories
{
    public interface IAbstractFactory
    {
        Coin MakeCoin(int value);
        Banknote MakeBanknote(int value);
    }
}