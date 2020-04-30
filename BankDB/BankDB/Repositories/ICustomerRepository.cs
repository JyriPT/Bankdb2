using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Repositories
{
    public interface ICustomerRepository
    {
        Customer Create(Customer newCustomer);
        Customer Read(int id);
        List<Customer> Read(Bank bank);
        Customer Update(Customer customer);
        void Delete(Customer customer);
    }
}
