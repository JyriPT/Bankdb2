using BankDB.Models;
using BankDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Services
{
    class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        //Constructor
        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }

        //Create customer
        public Customer Create(Customer newCustomer)
        {
            var createdCustomer = _customerRepository.Create(newCustomer);
            return createdCustomer;
        }

        //Delete customer based on id, informs if process succeeded
        public void Delete(int id)
        {
            var getCustomer = Read(id);

            if (getCustomer == null)
            {
                Console.WriteLine("Deletion failed, customer not found.");
            } else
            {
                _customerRepository.Delete(getCustomer);
                Console.WriteLine("Customer deleted");
            }
        }

        //Get list of customers associated with a bank
        public List<Customer> Read(Bank bank)
        {
            var customers = _customerRepository.Read(bank);
            return customers;
        }

        //Get customer based on id
        public Customer Read(int id)
        {
            var customer = _customerRepository.Read(id);
            return customer;
        }

        //Update customer
        public Customer Update(Customer customer)
        {
            var updateCustomer = _customerRepository.Update(customer);
            return updateCustomer;
        }
    }
}
