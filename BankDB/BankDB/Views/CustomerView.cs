using BankDB.Models;
using BankDB.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Views
{
    class CustomerView : ICustomerView
    {
        private readonly ICustomerService _customerService = new CustomerService();

        //Create customer entity
        //Returns Customer entity for use in account creation
        public Customer CreateCustomer(Bank bank)
        {
            string input = String.Empty;
            Customer newCustomer = new Customer();

            //Ask for first and last name
            do
            {
                Console.WriteLine("Enter first name of customer:");
                input = Console.ReadLine();
            } while (input == String.Empty);

            newCustomer.Firstname = input;
            input = String.Empty;

            do
            {
                Console.WriteLine("Enter surname of customer:");
                input = Console.ReadLine();
            } while (input == String.Empty);

            newCustomer.Lastname = input;

            newCustomer.BankId = bank.Id;

            //Create and return new entity
            var createdCustomer = _customerService.Create(newCustomer);
            return createdCustomer;
        }

        //Updates a customer
        public void UpdateCustomer()
        {
            //Asks for customer id, searches
            Console.WriteLine("Enter id of customer to update:");
            var input = Console.ReadLine();

            int id = int.Parse(input);

            var customer = _customerService.Read(id);

            //If found, asks for new information and updates
            //Prints info of updated entity
            if (customer != null)
            {
                Console.WriteLine($"Customer: {customer.Firstname} {customer.Lastname}.");
                Console.WriteLine("Enter new first name:");
                input = Console.ReadLine();
                customer.Firstname = input;

                Console.WriteLine("Enter new surname:");
                input = Console.ReadLine();
                customer.Lastname = input;

                var updatedCustomer = _customerService.Update(customer);
                Console.WriteLine($"New customer name: {customer.Firstname} {customer.Lastname}.");
            } else
            {
                Console.WriteLine("Customer not found, check id.");
            }
        }

        //Deletes a customer
        public void DeleteCustomer()
        {
            Console.WriteLine("Enter id of customer to delete:");
            var input = Console.ReadLine();

            if (int.TryParse(input, out int id) == true)
            {
                _customerService.Delete(id);
            } else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }

        //Prints data of all customers associated with a specific bank
        public void ReadAll(Bank bank)
        {
            var customers = _customerService.Read(bank);

            if (customers != null)
            {
                Console.WriteLine("Customer full names:");
                foreach (Customer customer in customers)
                {
                    Console.WriteLine($"{customer.Firstname}\t{customer.Lastname}");
                }
            }
            else
            {
                Console.WriteLine("No customers found.");
            }
        }

        //Finds and returns a customer entity based on ID
        //Returns null if finds nothing
        public Customer ReadCustomer()
        {
            Console.WriteLine("Enter id of wanted customer:");

            if (int.TryParse(Console.ReadLine(), out int id) == true)
            {
                var customer = _customerService.Read(id);
                return customer;
            }

            Console.WriteLine("Customer not found, try again.");
            return null;
        }
    }
}
