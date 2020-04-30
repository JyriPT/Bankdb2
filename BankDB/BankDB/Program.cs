using System;
using BankDB.Data;
using BankDB.Models;
using BankDB.Views;

namespace BankDB
{
    class Program
    {
        //static private readonly BankdbContext context = new BankdbContext();
        static private readonly IBankView _bankView = new BankView();
        static private readonly ICustomerView _customerView = new CustomerView();
        static private readonly IAccountView _accountView = new AccountView();
        static private readonly ITransactionView _transactionView = new TransactionView();

        static void Main(string[] args)
        {

            string choice = null;

            string msg = "";

            //Switch case for selection inside do-while loop
            do
            {
                choice = UserInterface();

                switch (choice.ToUpper())
                {
                    case "BANK":
                        BankSelection();
                        msg = "Press enter to return to start.";
                        break;

                    case "NEWCUSTOMER":
                        CustomerCreation();
                        msg = "Press enter to return to start.";
                        break;

                    case "BANKACCOUNTS":
                        BankAccounts();
                        msg = "Press enter to return to start.";
                        break;

                    case "BANKCUSTOMERS":
                        BankCustomers();
                        msg = "Press enter to return to start.";
                        break;

                    case "CHANGECUSTOMER":
                        ChangeCustomer();
                        msg = "Press enter to return to start.";
                        break;

                    case "DELETEACCOUNT":
                        _accountView.DeleteAccount();
                        msg = "Press enter to return to start.";
                        break;

                    case "CUSTOMERACCOUNTS":
                        CustomerAccounts();
                        msg = "Press enter to return to start.";
                        break;

                    case "TRANSACTION":
                        Transaction();
                        msg = "Press enter to return to start.";
                        break;

                    case "CUSTOMERTRANSACTIONS":
                        CustomerTransactions();
                        msg = "Press enter to return to start.";
                        break;

                    case "X":
                        msg = "Shutting down...";
                        break;

                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        msg = "Press enter to retry.";
                        break;
                }

                Console.WriteLine(msg);
                Console.ReadLine();
                Console.Clear();
            }
            while (choice.ToUpper() != "X");

        }

        //UI printed at start
        static string UserInterface()
        {
            Console.WriteLine("Bank app");
            Console.WriteLine("[Bank] Create/Update/Delete Bank");
            Console.WriteLine("[NewCustomer] Create a new customer with associated bank account");
            Console.WriteLine("[BankAccounts] List all accounts associated with a specific bank");
            Console.WriteLine("[BankCustomers] List all customers associated with a specific bank");
            Console.WriteLine("[ChangeCustomer] Update or delete existing customer information");
            Console.WriteLine("[DeleteAccount] Delete an account and all associated information");
            Console.WriteLine("[CustomerAccounts] List all accounts owned by a specific user");
            Console.WriteLine("[Transaction] Make a transaction to/from an account");
            Console.WriteLine("[CustomerTransactions] List all transactions on accounts owned by a specific customer");
            Console.WriteLine("[X] Quit program");
            Console.WriteLine();
            Console.Write("Select operation: ");

            return Console.ReadLine();
        }

        //Selection for bank related functions
        static void BankSelection()
        {
            string select;

            do
            {
                Console.WriteLine("Select function:");
                Console.WriteLine("[C] Create");
                Console.WriteLine("[U] Update");
                Console.WriteLine("[D] Delete");
                Console.WriteLine("[X] To cancel and return to main menu");

                select = Console.ReadLine();

                switch (select.ToUpper())
                {
                    case "C":
                        _bankView.CreateBank();
                        break;

                    case "U":
                        _bankView.UpdateBank();
                        break;

                    case "D":
                        _bankView.DeleteBank();
                        break;

                    case "X":
                        Console.WriteLine("Returning to main menu.");
                        break;

                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }
            } while (select.ToUpper() != "X");
        }

        //Creating customer with account, accesses multiple tables
        static void CustomerCreation()
        {
            Bank bank = _bankView.ReadBank();

            if (bank != null)
            {
                Customer customer = _customerView.CreateCustomer(bank);

                _accountView.CreateAccount(customer);
            } else
            {
                Console.WriteLine("Bank not found, please try again.");
            }
        }

        //Listing all accounts with a specific bank, accesses multiple tables
        static void BankAccounts()
        {
            Bank bank = _bankView.ReadBank();

            _accountView.ReadAll(bank);
        }

        //Listing all customers with a specific bank, accesses multiple tables
        static void BankCustomers()
        {
            Bank bank = _bankView.ReadBank();

            _customerView.ReadAll(bank);
        }

        //Selection for customer changes, update/delete
        //DELETE FUNCTION DOES NOT WORK, GIVES ERROR DUE TO FOREIGN KEY
        static void ChangeCustomer()
        {
            string select;

            do
            {
                Console.WriteLine("Select function");
                Console.WriteLine("[U] to update");
                Console.WriteLine("[D] to delete");
                Console.WriteLine("[X] To cancel and return to main menu");

                select = Console.ReadLine();

                switch (select.ToUpper())
                {
                    case "U":
                        _customerView.UpdateCustomer();
                        break;

                    case "D":
                        _customerView.DeleteCustomer();
                        break;

                    case "X":
                        Console.WriteLine("Returning to main menu.");
                        break;

                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }

            } while (select.ToUpper() != "X");
        }

        //Listing all accounts of a specific customer, accesses multiple tables
        static void CustomerAccounts()
        {
            Customer customer = _customerView.ReadCustomer();

            _accountView.ReadAll(customer);
        }

        //Make new transaction and update accounts accordingly, accesses multiple tables
        static void Transaction()
        {
            Transaction transaction = _transactionView.CreateTransaction();

            if (transaction != null)
            {
                _accountView.UpdateAccount(transaction);
            }
        }

        //Print all transactions associated with a specific customer, accesses multiple tables
        static void CustomerTransactions()
        {
            var customer = _customerView.ReadCustomer();

            if (customer != null)
            {
                var accounts = _accountView.GetAccounts(customer);

                if (accounts != null)
                {
                    _transactionView.ReadAll(accounts);
                }
            }
        }
    }
}
