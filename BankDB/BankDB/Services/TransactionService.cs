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

        //Constructor
        public TransactionService()
        {
            _transactionRepository = new TransactionRepository();
        }

        //Create transaction
        public Transaction Create(Transaction transaction)
        {
            Transaction newTransaction = _transactionRepository.Create(transaction);
            return newTransaction;
        }

        //Get list of transactions associated with an account
        public List<Transaction> Read(Account account)
        {
            var transaction = _transactionRepository.Read(account);
            return transaction;
        }
    }
}
