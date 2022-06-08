using System;
using System.Collections.Generic;
using System.Text;
using ORPZ_lab5.ChainOfResponsibility;
using ORPZ_lab5.Entities;
using ORPZ_lab5.Factories;
using ORPZ_lab5.Models;

namespace ORPZ_lab5
{
    // Реалізувати задачу обрахунку кількості грошей, котрі завантажив 
    // відвідувач, в термінал по прийому грошей. Передбачити, що окремо
    // можливість приймати монети та банкноти. Крім того, для монет різного
    // номіналу існують окремі прийомники. Виводити загальну внесену суму та
    // кількість монет та банкнот кожного номіналу окремо.
    class Program
    {
        static void Main(string[] args)
        {
            IAbstractFactory usdFactory = new UsdFactory();

            var coin5 = usdFactory.MakeCoin(5);
            var coin10 = usdFactory.MakeCoin(10);
            var coin50 = usdFactory.MakeCoin(50);
            var banknote5 = usdFactory.MakeBanknote(5);
            var banknote10 = usdFactory.MakeBanknote(10);
            var banknote50 = usdFactory.MakeBanknote(50);
            
            Terminal terminal = new CoinTerminal(coin5);
            terminal.SetNext(new CoinTerminal(coin10))
                .SetNext(new CoinTerminal(coin50))
                .SetNext(new BanknoteTerminal(banknote5))
                .SetNext(new BanknoteTerminal(banknote10))
                .SetNext(new BanknoteTerminal(banknote50));

            string report = GetReport(terminal);
            Console.WriteLine(report);
            
            terminal.Add(coin5);
            terminal.Add(coin5);
            terminal.Add(coin50);
            terminal.Add(banknote10);
            terminal.Add(banknote10);
            terminal.Add(banknote10);

            report = GetReport(terminal);
            Console.WriteLine(report);
        }

        public static string GetReport(Terminal startTerminal)
        {
            MoneyCountModel model = startTerminal.Calculate();

            StringBuilder report = new StringBuilder();
            report.AppendLine($"Total sum: {model.TotalSum}");
            
            report.AppendLine("Banknotes:");
            foreach (var banknotePair in model.BanknoteCount)
            {
                report.AppendLine($"Banknote value: {banknotePair.Key}     Count: {banknotePair.Value}");
            }

            report.AppendLine("Coins: ");
            foreach (var coinPair in model.CoinsCount)
            {
                report.AppendLine($"Coin value: {coinPair.Key}     Count: {coinPair.Value}");
            }

            return report.ToString();
        }
    }
}