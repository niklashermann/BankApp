using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class Transaction
    {
        public decimal Menge 
        {
            get; 
        }
        public DateTime Datum
        {
            get;
        }
        public string Noten
        {
            get;
        }

        public Transaction(decimal menge, DateTime datum, string noten)
        {
            Menge = menge;
            Datum = datum;
            Noten = noten;
        }
    }
}
