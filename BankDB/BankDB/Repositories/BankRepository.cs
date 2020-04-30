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

        //Constructor
        public BankRepository()
        {
            _context = new BankdbContext();
        }

        //Add bank into database, produce error if given
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

        //Delete bank from database
        public void Delete(Bank deleteBank)
        {
            _context.Bank.Remove(deleteBank);
            _context.SaveChanges();
        }

        //Get bank from databse with matching id
        public Bank Read(int id)
        {
            var bank = _context
                .Bank
                .FirstOrDefault(p => p.Id == id);
            return bank;
        }

        //Update bank in database
        public Bank Update(Bank updateBank)
        {
            _context.Bank.Update(updateBank);
            _context.SaveChanges();
            return updateBank;
        }
    }
}
