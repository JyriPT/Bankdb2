using BankDB.Data;
using BankDB.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankDB.Repositories
{
    class BankRepository : IBankRepository
    {
        private readonly BankdbContext _context;

        public BankRepository()
        {
            _context = new BankdbContext();
        }
        public Bank Create(Bank newBank)
        {
            try
            {
                _context.Bank.Add(newBank);
                _context.SaveChanges();
                return newBank;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public void Delete(Bank deleteBank)
        {
            _context.Bank.Remove(deleteBank);
            _context.SaveChanges();
        }

        public Bank Read(int id)
        {
            var bank = _context
                .Bank
                .FirstOrDefault(p => p.Id == id);
            return bank;
        }

        public Bank Update(Bank updateBank)
        {
            _context.Bank.Update(updateBank);
            _context.SaveChanges();
            return updateBank;
        }
    }
}
