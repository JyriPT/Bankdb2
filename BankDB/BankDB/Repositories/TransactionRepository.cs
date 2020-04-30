using BankDB.Data;
using BankDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDB.Repositories
{
    class TransactionRepository : ITransactionRepository
    {
        private readonly BankdbContext _context;

        //constructor
        public TransactionRepository()
        {
            _context = new BankdbContext();
        }

        //Add transaction to database, produce error if given
        public Transaction Create(Transaction transaction)
        {
            try
            {
                _context.Transaction.Add(transaction);
                _context.SaveChanges();
                return transaction;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        //Get from databse list of transactions that match Iban value of an Account entity, produce error if given
        public List<Transaction> Read(Account account)
        {
            try
            {
                var transactions = _context
                    .Transaction
                    .Include(p => p.IbanNavigation)
                    .Where(p => p.Iban == account.Iban)
                    .ToList();

                return transactions;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }
    }
}
