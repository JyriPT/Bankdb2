using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Views
{
    public interface IBankView
    {
        void CreateBank();
        Bank ReadBank();
        void UpdateBank();
        void DeleteBank();
    }
}
