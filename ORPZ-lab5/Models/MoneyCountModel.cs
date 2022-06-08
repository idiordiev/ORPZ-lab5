using System.Collections.Generic;

namespace ORPZ_lab5.Models
{
    public class MoneyCountModel
    {
        public decimal TotalSum { get; set; }
        public Dictionary<int, int> CoinsCount { get; set; }
        public Dictionary<int, int> BanknoteCount { get; set; }

        public MoneyCountModel()
        {
            CoinsCount = new Dictionary<int, int>();
            BanknoteCount = new Dictionary<int, int>();
        }
    }
}