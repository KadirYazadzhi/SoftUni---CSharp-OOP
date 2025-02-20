namespace CustomRandomList;

public class RandomList : List<string> {
    public string RandomString() {
        int random = Random.Shared.Next(this.Count);
        
        string randomValue = this[random];
        this.RemoveAt(random);
        
        return randomValue;
    }
}