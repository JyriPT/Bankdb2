using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Repositories
{
    public interface IAccountRepository
    {
        Account Create(Account newAccount);
        List<Account> Read(Bank bank);
        List<Account> Read(Customer customer);
        Account Read(string IBAN);
        void Update(Account account);
        void Delete(Account account);
    }
}
