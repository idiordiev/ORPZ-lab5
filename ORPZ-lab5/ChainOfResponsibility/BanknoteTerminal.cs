using System;
using ORPZ_lab5.Entities;
using ORPZ_lab5.Models;

namespace ORPZ_lab5.ChainOfResponsibility
{
    public class BanknoteTerminal : Terminal
    {
        public BanknoteTerminal(Banknote banknote) : base(banknote)
        {
        }

        public override void Add(Money money)
        {
            if (money is Banknote && money.Value == Sample.Value && money.Currency == Sample.Currency)
                Count++;
            else if (NextTerminal != null)
                NextTerminal.Add(money);
            else
                throw new Exception("The terminal you need has not been found.");
        }

        public override MoneyCountModel Calculate(MoneyCountModel model = null)
        {
            if (model == null)
                model = new MoneyCountModel();

            model.TotalSum += Sample.Value * Count;
            
            if (model.BanknoteCount.ContainsKey(Sample.Value))
                model.BanknoteCount[Sample.Value] += Count;
            else
                model.BanknoteCount[Sample.Value] = Count;

            return NextTerminal == null ? model : NextTerminal.Calculate(model);
        }
    }
}