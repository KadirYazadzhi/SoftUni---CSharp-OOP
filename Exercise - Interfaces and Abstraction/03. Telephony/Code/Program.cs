using System;
using System.Text.RegularExpressions;

namespace Telephony;

public class StartUp {
    public static void Main(string[] args) {
        string[] numbers = Console.ReadLine().Split(" ");
        string[] urls = Console.ReadLine().Split(" ");

        for (int i = 0; i < numbers.Length; i++){
            if (IsValidPhoneNumber(numbers[i])){
                if (numbers[i].Length == 10) new Smartphone().Call(numbers[i]);
                else new StationaryPhone().Call(numbers[i]);
            }
            else{
                Console.WriteLine("Invalid number!");
            }
        }

        for (int i = 0; i < urls.Length; i++){
            if (IsValidUrl(urls[i])) new Smartphone().Browse(urls[i]);
            else Console.WriteLine("Invalid URL!");
        }
    }
    

    static bool IsValidPhoneNumber(string number) => number.All(char.IsDigit) && number.Length >= 7 && number.Length <= 10;
    
    static bool IsValidUrl(string url) => !url.Any(char.IsDigit);
    
}