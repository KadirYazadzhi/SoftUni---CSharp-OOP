namespace Telephony;

public class StationaryPhone : IPhone {

    public void Call(string number) => Console.WriteLine($"Dialing... {number}");
    
}