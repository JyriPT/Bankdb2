using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Services
{
    public interface ITransactionService
    {
        Transaction Create(Transaction transaction);
        List<Transaction> Read(Account account);
    }
}
