using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacktLibrary
{
    public class BankAccount
    {
        public string? AccountName;          // instant member
        public decimal Balance;             // instance member
        public static decimal InterestRate; // shared member
    }
}
