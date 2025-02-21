using System;
using System.Collections.Generic;
using System.Linq;

namespace Person {
    public class StartUp {
        public static void Main(string[] args) {
           string name = Console.ReadLine();
           int age = int.Parse(Console.ReadLine());
           
           if (age < 0) Console.WriteLine("Age must be positive!");
           else if (age > 15) Console.WriteLine(new Person(name, age));
           else Console.WriteLine(new Child(name, age));
        }
    }
}