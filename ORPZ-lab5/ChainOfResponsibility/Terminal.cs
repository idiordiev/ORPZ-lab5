using ORPZ_lab5.Entities;
using ORPZ_lab5.Models;

namespace ORPZ_lab5.ChainOfResponsibility
{
    public abstract class Terminal
    {
        protected Terminal NextTerminal;
        protected Money Sample;
        protected int Count;

        protected Terminal(Money sample)
        {
            Sample = sample;
        }

        public abstract void Add(Money money);

        public abstract MoneyCountModel Calculate(MoneyCountModel model = null);

        public Terminal SetNext(Terminal terminal)
        {
            NextTerminal = terminal;
            return NextTerminal;
        }
    }
}