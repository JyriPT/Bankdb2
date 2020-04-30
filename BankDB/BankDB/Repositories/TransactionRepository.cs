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
        public TransactionRepository()
        {
            _context = new BankdbContext();
        }

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
