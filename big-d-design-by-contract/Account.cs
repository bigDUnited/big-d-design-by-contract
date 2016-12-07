using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace big_d_design_by_contract
{
    internal class Account
    {
        private double _balance;

        public Account(double balance)
        {
            _balance = balance;
        }

        public void Deposit(double amount)
        {
            Contract.Requires<MoneyException>(amount > 0);
            Contract.EnsuresOnThrow<MoneyException>(
                Contract.OldValue<double>(_balance) == _balance
            );
            //if (amount < 0) throw new MoneyException();
            //Contract.EndContractBlock();
            _balance += amount;
        }

        public void Withdraw(double amount)
        {
            Contract.Requires<MoneyException>(amount > 0);
            //Contract.Requires<MoneyException>(_balance - amount >= 0);

            Contract.EnsuresOnThrow<MoneyException>(
                Math.Abs(Contract.OldValue<double>(_balance) - _balance) < 0.01
            );
            //if (!(_balance >= amount) || !(amount > 0)) throw new MoneyException();
            _balance -= amount;
        }

        [ContractInvariantMethod]
        private void Invariant()
        {
            Contract.Invariant(
                _balance >= 0
            );
        }
    }

    internal class MoneyException : Exception
    {
    }
}