namespace PersonsInfo;

public class Person {
    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }

    public Person(string firstName, string lastName, int age) {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public override string ToString() {
        return $"{FirstName} {LastName} is {Age} years old.";
    }
}