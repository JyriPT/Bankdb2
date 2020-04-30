using BankDB.Models;
using BankDB.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Views
{
    class AccountView : IAccountView
    {
        private readonly IAccountService _accountService = new AccountService();

        //Creates an account for a given customer
        public void CreateAccount(Customer customer)
        {
            Account newAccount = new Account();
            string input = String.Empty;

            //Apply info from given customer
            newAccount.BankId = customer.BankId;
            newAccount.CustomerId = customer.Id;

            //Ask for missing information
            do
            {
                Console.WriteLine("Enter a name for the account:");
                input = Console.ReadLine();
            } while (input == String.Empty);
            newAccount.Name = input;
            input = String.Empty;

            do
            {
                Console.WriteLine("Enter IBAN code for the account:");
                input = Console.ReadLine();
            } while (input == String.Empty);
            newAccount.Iban = input;
            input = String.Empty;

            do
            {
                Console.WriteLine("Enter starting account balance:");
                input = Console.ReadLine();

                if (int.TryParse(input, out int balance) == true && input != String.Empty)
                {
                    newAccount.Balance = balance;
                }
            } while (input == String.Empty);

            //Create new account, check to see if it worked
            var createdAccount = _accountService.Create(newAccount);

            if (createdAccount != null)
            {
                Console.WriteLine("Account creation successful.");
            } else
            {
                Console.WriteLine("Account creation failed.");
            }
        }

        //Asks for an account to be deleted, starts deleting
        public void DeleteAccount()
        {
            Console.WriteLine("Enter IBAN of account to be deleted:");
            var input = Console.ReadLine();

            _accountService.Delete(input);
        }

        //Returns list of all accounts associated with a specific customer
        public List<Account> GetAccounts(Customer customer)
        {
            //Get a list of all accounts
            var accounts = _accountService.Read(customer);

            //If list exists, return list
            if (accounts != null)
            {
                return accounts;
            }
            else
            {
                Console.WriteLine("No accounts found.");
                return null;
            }
        }

        //Reads data of all accounts from a given bank
        public void ReadAll(Bank bank)
        {
            //Get a list of all accounts
            var accounts = _accountService.Read(bank);

            //If list exists, loop through printing
            if (accounts != null)
            {
                Console.WriteLine("IBAN\t\t\tName\t\tCustomer ID\tBalance");
                foreach (Account account in accounts)
                {
                    Console.WriteLine($"{account.Iban}\t{account.Name}\t{account.CustomerId}\t{account.Balance}");
                }
            } else
            {
                Console.WriteLine("No accounts found.");
            }
        }

        //Prints data of all accounts associated with a specific customer
        public void ReadAll(Customer customer)
        {
            //Get a list of all accounts
            var accounts = _accountService.Read(customer);

            //If list exists, loop through printing
            if (accounts != null)
            {
                Console.WriteLine("IBAN\t\t\tName\t\tCustomer ID\tBalance");
                foreach (Account account in accounts)
                {
                    Console.WriteLine($"{account.Iban}\t{account.Name}\t{account.CustomerId}\t{account.Balance}");
                }
            }
            else
            {
                Console.WriteLine("No accounts found.");
            }
        }

        //Updates an account, used in conjunction with transaction creation
        public void UpdateAccount(Transaction transaction)
        {
            Account account = _accountService.Read(transaction.Iban);

            account.Balance += transaction.Amount;

            _accountService.Update(account);
        }
    }
}
