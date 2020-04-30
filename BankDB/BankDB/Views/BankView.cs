using BankDB.Services;
using BankDB.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankDB.Views
{
    class BankView : IBankView
    {
        private readonly IBankService _bankService = new BankService();

        //Creates a bank
        public void CreateBank()
        {
            Bank newBank = new Bank();
            string input = string.Empty;

            //Asks for name
            while (input == string.Empty)
            {
                Console.WriteLine("Enter name of new bank:");
                input = Console.ReadLine();
            }

            newBank.Name = input;
            input = String.Empty;

            //Asks for BIC code (should be automatically generated I think, but isn't here for simplicity)
            while (input == string.Empty)
            {
                Console.WriteLine("Enter BIC of new bank:");
                input = Console.ReadLine();
            }

            newBank.Bic = input;

            //Create
            var createdBank = _bankService.Create(newBank);
            Console.WriteLine(createdBank.Name);
        }

        //Deletes a bank
        //Asks for Id, then starts deleting if found
        public void DeleteBank()
        {
            Console.Write("Enter the id of bank to be deleted:");
            var userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int id) == true)
            {
                _bankService.Delete(id);
            } else
            {
                Console.WriteLine("Invalid input, please try again.");
            }
        }

        //Finds a bank entity based on id
        //Returns null if finds nothing
        public Bank ReadBank()
        {
            Console.WriteLine("Enter id of wanted bank:");

            if (int.TryParse(Console.ReadLine(), out int id) == true)
            {
                var bank = _bankService.Read(id);
                return bank;
            }

            Console.WriteLine("Bank not found, try again.");
            return null;
        }

        //Updates a bank
        public void UpdateBank()
        {
            //Asks for id of bank to update
            Console.Write("Enter id of bank to be updated:");
            var userInput = Console.ReadLine();

            int id = int.Parse(userInput);

            var bank = _bankService.Read(id);

            //If found, asks for new name and begins updating
            //If not, gives error
            if (bank != null)
            {
                Console.WriteLine("Give new name for bank:");
                userInput = Console.ReadLine();

                bank.Name = userInput;
                var updatedBank = _bankService.Update(bank);

                PrintBankData(updatedBank);
            } else
            {
                Console.WriteLine("Bank not found, check id.");
            }
            
        }

        //Prints data of a given bank
        private void PrintBankData(Bank bank)
        {
            Console.WriteLine("ID\tNimi\tBIC");
            Console.WriteLine($"{bank.Id}\t{bank.Name}\t{bank.Bic}");
        }
    }
}
