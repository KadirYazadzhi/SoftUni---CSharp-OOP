namespace ShoppingSpree;

using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void Main() {
        try {
            var people = new Dictionary<string, Person>();
            var products = new Dictionary<string, Product>();

            string[] peopleInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in peopleInput) {
                var data = p.Split('=');
                people[data[0]] = new Person(data[0], decimal.Parse(data[1]));
            }

            string[] productInput = Console.ReadLine().Split(';', StringSplitOptions.RemoveEmptyEntries);
            foreach (var p in productInput) {
                var data = p.Split('=');
                products[data[0]] = new Product(data[0], decimal.Parse(data[1]));
            }

            string command;
            while ((command = Console.ReadLine()) != "END") {
                var data = command.Split();
                string personName = data[0];
                string productName = data[1];

                if (people.ContainsKey(personName) && products.ContainsKey(productName)) people[personName].BuyProduct(products[productName]);
                
            }

            foreach (var person in people.Values) {
                Console.WriteLine(person.Bag.Count > 0
                    ? $"{person.Name} - {string.Join(", ", person.Bag.Select(p => p.Name))}"
                    : $"{person.Name} - Nothing bought");
            }
        }
        catch (ArgumentException ex) {
            Console.WriteLine(ex.Message);
        }
    }
}


