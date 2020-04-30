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

        //Constructor
        public AccountService()
        {
            _accountRepository = new AccountRepository();
        }

        //Create account
        public Account Create(Account newAccount)
        {
            var createdAccount = _accountRepository.Create(newAccount);
            return createdAccount;
        }

        //Delete account based on IBAN string, informs if process succeeded
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

        //Get list of accounts associated with bank
        public List<Account> Read(Bank bank)
        {
            var accounts = _accountRepository.Read(bank);
            return accounts;
        }

        //Get account based on IBAN
        public Account Read(string IBAN)
        {
            var account = _accountRepository.Read(IBAN);
            return account;
        }

        //Get list of accounts associated with customer
        public List<Account> Read(Customer customer)
        {
            var accounts = _accountRepository.Read(customer);
            return accounts;
        }

        //Update account
        public void Update(Account account)
        {
            _accountRepository.Update(account);
        }
    }
}
