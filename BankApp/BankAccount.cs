using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class BankAccount
    {

    private static int accountNumberSeed = 5633;
        private List<Transaction> allTransactions = new List<Transaction>();

        public string Nummer 
        { 
            get; 
        }
        public string Besitzer 
        { 
            get;
            set; 
        }
        public decimal Kontostand 
        { 
            get
            {
                decimal kontostand = 0;
                //foreach (var item in allTransactions)
                foreach (Transaction item in allTransactions)
                {
                    kontostand += item.Menge;
                }
                return kontostand;
            } 
        }

        public void Einzahlung(decimal menge, DateTime datum, string noten)
        {
            if (menge < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(menge), "Menge der Einzahlung muss positiv sein!");
            }
            var einzahlung = new Transaction(menge, datum, noten);
            allTransactions.Add(einzahlung);
        }

        public void Auszahlung(decimal menge, DateTime datum, string noten)
        {
            if (menge <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(menge), "Menge der Auszahlung muss positiv sein!");
            }
            if (Kontostand - menge < 0)
            {
                throw new InvalidOperationException("Nicht genügend Guthaben für diese Auszahlung.");
            }
            var auszahlung = new Transaction(-menge, datum, noten);
            allTransactions.Add(auszahlung);
        }

        public BankAccount(string name)
        {
            Nummer = accountNumberSeed.ToString();
            accountNumberSeed++;

            Besitzer = name;
            Einzahlung(0, DateTime.Now, "initialer Kontostand");
        }

        public string GetAccountHistory()
        {
            var report = new System.Text.StringBuilder();

            decimal konstostand = 0;
            report.AppendLine("Datum\t\tMenge\tKontostand\tNotes");
            foreach (Transaction item in allTransactions)
            {
                konstostand += item.Menge;
                report.AppendLine($"{item.Datum.ToShortDateString()}\t{item.Menge}\t{konstostand}\t{item.Noten}");
            }
            return report.ToString();
        }
        
    }
    
}

