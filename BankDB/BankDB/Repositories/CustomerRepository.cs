using BankDB.Data;
using BankDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDB.Repositories
{
    class CustomerRepository : ICustomerRepository
    {
        private readonly BankdbContext _context;

        public CustomerRepository()
        {
            _context = new BankdbContext();
        }

        public Customer Create(Customer newCustomer)
        {
            try
            {
                _context.Customer.Add(newCustomer);
                _context.SaveChanges();
                return newCustomer;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public void Delete(Customer customer)
        {
            _context.Customer.Remove(customer);
            _context.SaveChanges();
        }

        public List<Customer> Read(Bank bank)
        {
            try
            {
                var customers = _context
                .Customer
                .Include(p => p.Bank)
                .Where(p => p.BankId == bank.Id)
                .ToList();

                return customers;
            }
            
            catch
            {
                return null;
            }
        }

        public Customer Read(int id)
        {
            var customer = _context
                .Customer
                .FirstOrDefault(p => p.Id == id);
            return customer;
        }

        public Customer Update(Customer updateCustomer)
        {
            _context.Update(updateCustomer);
            _context.SaveChanges();
            return updateCustomer;
        }
    }
}
