using BankDB.Models;
using BankDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Services
{
    class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        public Account Create(Account newAccount)
        {
            var createdAccount = _accountRepository.Create(newAccount);
            return createdAccount;
        }

        public void Delete(string IBAN)
        {
            var getAccount = Read(IBAN);

            if (getAccount == null)
            {
                Console.WriteLine("Deletion failed, account not found");
            } else
            {
                _accountRepository.Delete(getAccount);
                Console.WriteLine("Account deleted");
            }
        }

        public List<Account> Read(Bank bank)
        {
            var accounts = _accountRepository.Read(bank);
            return accounts;
        }

        public Account Read(string IBAN)
        {
            var account = _accountRepository.Read(IBAN);
            return account;
        }

        public List<Account> Read(Customer customer)
        {
            var accounts = _accountRepository.Read(customer);
            return accounts;
        }

        public void Update(Account account)
        {
            _accountRepository.Update(account);
        }
    }
}
