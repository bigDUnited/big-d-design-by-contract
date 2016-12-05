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

        public bool Deposit(double amount)
        {
            Contract.Requires(amount > 0);
            Contract.Ensures(
                Contract.Result<bool>() == true || false
            );
            Contract.EnsuresOnThrow<MoneyException>(
                Math.Abs(Contract.OldValue<double>(_balance) - _balance) < 0.01
            );
            if (amount < 1) throw new MoneyException();
            _balance += amount;
            return true;
        }

        public bool Withdraw(double amount)
        {
            Contract.Requires(amount > 0);
            Contract.Requires(_balance - amount > 0);
            Contract.Ensures(
                Contract.Result<bool>() == true || false
            );
            Contract.EnsuresOnThrow<MoneyException>(
                Math.Abs(Contract.OldValue<double>(_balance) - _balance) < 0.01
            );
            if (!(_balance >= amount) || !(amount > 0)) throw new MoneyException();
            _balance -= amount;
            return true;
        }
    }

    internal class MoneyException : Exception
    {
    }
}