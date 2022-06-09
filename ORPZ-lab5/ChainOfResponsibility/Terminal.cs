using ORPZ_lab5.Entities;
using ORPZ_lab5.Models;

namespace ORPZ_lab5.ChainOfResponsibility
{
    public abstract class Terminal
    {
        protected Terminal _nextTerminal;
        protected Money _sample;
        protected int _count;

        protected Terminal(Money sample)
        {
            _sample = sample;
        }

        public abstract void Add(Money money);

        public abstract MoneyCountModel Calculate(MoneyCountModel model = null);

        public Terminal SetNext(Terminal terminal)
        {
            _nextTerminal = terminal;
            return _nextTerminal;
        }
    }
}