using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Views
{
    public interface ITransactionView
    {
        Transaction CreateTransaction();
        void ReadAll(List<Account> accounts);
    }
}
