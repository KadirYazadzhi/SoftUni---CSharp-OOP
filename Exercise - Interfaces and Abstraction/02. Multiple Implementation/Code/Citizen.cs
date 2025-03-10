namespace PersonInfo;

public class Citizen : IPerson, IIdentifiable, IBirthable {
    public string Name { get;  }
    public int Age { get;  }
    public string Id { get;  }
    public string Birthdate { get;  }
    
    public Citizen(string name, int age, string id, string birthdate) {
        Name = name;
        Age = age;
        Birthdate = birthdate;
        Id = id;
    }
}