using BankDB.Data;
using BankDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDB.Repositories
{
    class AccountRepository : IAccountRepository
    {
        private readonly BankdbContext _context;

        //Constructor
        public AccountRepository()
        {
            _context = new BankdbContext();
        }

        //Add account to database, produce error if given
        public Account Create(Account newAccount)
        {
            try
            {
                _context.Account.Add(newAccount);
                _context.SaveChanges();
                return newAccount;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        //Delete account from database
        public void Delete(Account account)
        {
            _context.Account.Remove(account);
            _context.SaveChanges();
        }

        //Get list of accounts with Bankid that matches given entity
        public List<Account> Read(Bank bank)
        {
            try
            {
                var accounts = _context
                .Account
                .Include(p => p.Bank)
                .Where(p => p.BankId == bank.Id)
                .ToList();
                return accounts;
            }
            catch
            {
                return null;
            }
        }

        //Get account from database with matching IBAN
        public Account Read(string IBAN)
        {
            var account = _context
                .Account
                .FirstOrDefault(p => p.Iban == IBAN);
            return account;
        }

        //Get list of account from database with CustomerId that matches given entity
        public List<Account> Read(Customer customer)
        {
            try
            {
                var accounts = _context
                .Account
                .Include(p => p.Customer)
                .Where(p => p.CustomerId == customer.Id)
                .ToList();
                return accounts;
            }
            catch
            {
                return null;
            }
        }

        //Update account in database, produce error if given
        public void Update(Account account)
        {
            try
            {
                _context.Account.Update(account);
                _context.SaveChanges();
            } 
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}
