using System;
using System.Collections.Generic;

class Program {
    public static void Main() {
        CheckNumbers();
    }
    
    static int ReadNumber(int start, int end) {
        try {
            int number = int.Parse(Console.ReadLine());

            if (number <= start || number >= end) throw new ArgumentException($"Your number is not in range {start} - {end}!");

            return number;
        }
        catch (FormatException) {
            throw new FormatException("Invalid Number!");
        }
    }

    private static void CheckNumbers() {
        List<int> numbers = new List<int>();
        int start = 1, end = 100;

        while (numbers.Count < 10) {
            try {
                int num = ReadNumber(start, end);
                if (numbers.Count > 0 && num <= numbers[^1]) throw new ArgumentException($"Your number is not in range {numbers[^1]} - 100!");
                
                numbers.Add(num);
                start = num; 
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        Console.WriteLine(string.Join(", ", numbers));
    }
}

