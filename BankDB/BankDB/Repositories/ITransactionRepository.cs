using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Repositories
{
    public interface ITransactionRepository
    {
        Transaction Create(Transaction transaction);
        List<Transaction> Read(Account account);
    }
}
