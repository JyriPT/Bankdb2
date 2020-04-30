using BankDB.Models;
using BankDB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Services
{
    class BankService : IBankService
    {
        private readonly IBankRepository _bankRepository;

        //Constructor
        public BankService()
        {
            _bankRepository = new BankRepository();
        }

        //Create new Bank
        public Bank Create(Bank newBank)
        {
            var createdBank = _bankRepository.Create(newBank);
            return createdBank;
        }

        //Delete bank
        public void Delete(int id)
        {
            var getBank = Read(id);

            if (getBank == null)
            {
                Console.WriteLine("Deletion failed, bank not found");
            }
            else
            {
                _bankRepository.Delete(getBank);
                Console.WriteLine("Bank deleted");
            }
        }

        //Find bank based on Id
        public Bank Read(int id)
        {
            var bank = _bankRepository.Read(id);
            return bank;
        }

        //Update bank
        public Bank Update(Bank updateBank)
        {
            var updatedBank = _bankRepository.Update(updateBank);
            return updatedBank;
        }
    }
}
