using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Repositories
{
    public interface IBankRepository
    {
        Bank Create(Bank newBank);
        Bank Update(Bank updateBank);
        void Delete(Bank deleteBank);
        Bank Read(int id);
    }
}
