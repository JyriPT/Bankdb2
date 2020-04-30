using BankDB.Models;
using BankDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Services
{
    class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository; 

        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
        }

        public Transaction Create(Transaction transaction)
        {
            Transaction newTransaction = _transactionRepository.Create(transaction);
            return newTransaction;
        }

        public List<Transaction> Read(Account account)
        {
            var transaction = _transactionRepository.Read(account);
            return transaction;
        }
    }
}
