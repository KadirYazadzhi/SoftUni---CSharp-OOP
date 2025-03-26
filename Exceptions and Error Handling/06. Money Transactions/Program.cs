using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        Dictionary<int, double> accounts = Console.ReadLine().Split(',').Select(part => part.Split('-')).ToDictionary(split => int.Parse(split[0]), split => double.Parse(split[1]));

        string command;
        while ((command = Console.ReadLine()) != "End") {
            string[] parts = command.Split();
            
            try {
                if (parts.Length != 3) throw new ArgumentException("Invalid command!");

                string operation = parts[0];
                int accountNumber = int.Parse(parts[1]);
                double amount = double.Parse(parts[2]);

                if (!accounts.ContainsKey(accountNumber)) throw new KeyNotFoundException("Invalid account!");
                
                if (operation == "Deposit") {
                    accounts[accountNumber] += amount;
                }
                else if (operation == "Withdraw") {
                    if (accounts[accountNumber] < amount) throw new InvalidOperationException("Insufficient balance!");
                    
                    accounts[accountNumber] -= amount;
                }
                else {
                    throw new ArgumentException("Invalid command!");
                }
                
                Console.WriteLine($"Account {accountNumber} has new balance: {accounts[accountNumber]:F2}");
            }
            catch (ArgumentException e) {
                Console.WriteLine(e.Message);
            }
            catch (KeyNotFoundException e) {
                Console.WriteLine(e.Message);
            }
            catch (InvalidOperationException e) {
                Console.WriteLine(e.Message);
            }
            
            Console.WriteLine("Enter another command");
        }
    }
}

