using System;
using System.Collections.Generic;

public  class StartUp {
    static void Main(string[] args) {
        Square(int.Parse(Console.ReadLine()));
    }

    private static void Square(int num) {
        try {
            if (num < 0) throw new ArgumentException("Invalid number.");

            Console.WriteLine(Math.Sqrt(num));
        }
        catch (Exception ex) {
            Console.WriteLine("Invalid number.");
        }
        finally {
            Console.WriteLine("Goodbye.");
        }
    }
}
