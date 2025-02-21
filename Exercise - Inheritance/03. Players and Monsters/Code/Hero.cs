namespace PlayersAndMonsters;

public class Hero {
    public string Username { get; private set; }
    public int Level { get; private set; }

    public Hero(string name, int level) {
        Username = name;
        Level = level;
    }
    
    public override string ToString() {

        return $"Type: {this.GetType().Name} Username: {this.Username} Level: {this.Level}";

    } 
}