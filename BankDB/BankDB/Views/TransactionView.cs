using BankDB.Models;
using BankDB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDB.Views
{
    class TransactionView : ITransactionView
    {
        private readonly ITransactionService _transactionService = new TransactionService();

        //Creates a new transaction
        public Transaction CreateTransaction()
        {
            Transaction newTransaction = new Transaction();
            string input = String.Empty;
            int amount = 0;

            //Asks for IBAN of target acount
            do
            {
                Console.WriteLine("Enter IBAN of account to make transaction to/from:");
                
                input = Console.ReadLine();
            } while (input == String.Empty);

            newTransaction.Iban = input;

            //Asks for amount of transaction
            //Note - withdrawal untested
            do
            {
                Console.WriteLine("Enter amount to transact");
                Console.WriteLine("Positive value for deposit, negative value for withdrawal:");
                input = Console.ReadLine();

                if (int.TryParse(input, out amount) == true && amount > 0)
                {
                    newTransaction.Amount = amount;
                } else
                {
                    Console.WriteLine("Deposit must be a number greater than zero.");
                }
            } while (amount == 0);

            //Apply current timestamp
            newTransaction.TimeStamp = DateTime.Today;

            //Make transaction, check for failures
            newTransaction = _transactionService.Create(newTransaction);

            if (newTransaction == null)
            {
                Console.WriteLine("Transaction failed.");
            }

            return newTransaction;
        }

        //Lists all transactions associated with list of given accounts
        public void ReadAll(List<Account> accounts)
        {
            Console.WriteLine("Transaction amount\t\tTimestamp");

            foreach (Account account in accounts)
            {
                var transactions = _transactionService.Read(account);

                if (transactions != null)
                {
                    Print(transactions);
                }
            }
        }

        //Prints all transactions associated with list of given accounts
        public void Print(List<Transaction> transactions)
        {
            foreach (Transaction transaction in transactions)
            {
                Console.WriteLine($"{transaction.Amount}\t\t{transaction.TimeStamp}");
            }
        }
    }
}
