namespace Telephony;

public class Smartphone : IPhone, ISmartphone {
    public void Call(string number) => Console.WriteLine($"Calling... {number}");

    public void Browse(string url) => Console.WriteLine($"Browsing: {url}!");
    
}