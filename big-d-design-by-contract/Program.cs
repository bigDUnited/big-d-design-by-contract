using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace big_d_design_by_contract
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Account acc = new Account(20);
            Console.WriteLine(acc.Deposit(-1));
            Console.WriteLine(acc.Withdraw(-30));
            Console.ReadLine();
        }
    }
}
