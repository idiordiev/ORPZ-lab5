using System;
using ORPZ_lab5.Entities;
using ORPZ_lab5.Models;

namespace ORPZ_lab5.ChainOfResponsibility
{
    public class CoinTerminal : Terminal
    {
        public CoinTerminal(Coin sampleCoin) : base(sampleCoin)
        {
        }

        public override void Add(Money money)
        {
            if (money is Coin && money.Value == _sample.Value && money.Currency == _sample.Currency)
                _count++;
            else if (_nextTerminal != null)
                _nextTerminal.Add(money);
            else
                throw new Exception("The terminal you need has not been found.");
        }

        public override MoneyCountModel Calculate(MoneyCountModel model = null)
        {
            if (model == null)
                model = new MoneyCountModel();

            model.TotalSum += _sample.Value * _count * 0.01m;

            if (model.CoinsCount.ContainsKey(_sample.Value))
                model.CoinsCount[_sample.Value] += _count;
            else
                model.CoinsCount[_sample.Value] = _count;

            return _nextTerminal == null ? model : _nextTerminal.Calculate(model);
        }
    }
}