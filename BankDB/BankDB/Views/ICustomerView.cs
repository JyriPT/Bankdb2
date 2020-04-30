using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Views
{
    public interface ICustomerView
    {
        void UpdateCustomer();
        void DeleteCustomer();
        Customer CreateCustomer(Bank bank);
        void ReadAll(Bank bank);
        Customer ReadCustomer();
    }
}
