using System;
using System.Linq;

class Program {
    static void Main() {
        int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int exceptionCount = 0;

        while (exceptionCount < 3) {
            string[] commandParts = Console.ReadLine().Split();
            string command = commandParts[0];
            
            try {
                if (command == "Replace") {
                    int index = int.Parse(commandParts[1]);
                    int element = int.Parse(commandParts[2]);
                    numbers[index] = element;
                }
                else if (command == "Print") {
                    int startIndex = int.Parse(commandParts[1]);
                    int endIndex = int.Parse(commandParts[2]);
                    if (startIndex < 0 || endIndex >= numbers.Length)
                        throw new IndexOutOfRangeException();
                    Console.WriteLine(string.Join(", ", numbers.Skip(startIndex).Take(endIndex - startIndex + 1)));
                }
                else if (command == "Show") {
                    int index = int.Parse(commandParts[1]);
                    Console.WriteLine(numbers[index]);
                }
            }
            catch (IndexOutOfRangeException) {
                Console.WriteLine("The index does not exist!");
                exceptionCount++;
            }
            catch (FormatException) {
                Console.WriteLine("The variable is not in the correct format!");
                exceptionCount++;
            }
        }
        
        Console.WriteLine(string.Join(", ", numbers));
    }
}

