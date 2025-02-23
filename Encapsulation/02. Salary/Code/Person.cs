namespace PersonsInfo;

public class Person {
    public string FirstName { get; }
    public string LastName { get; }
    public int Age { get; }
    public decimal Salary { get; private set;  }

    public Person(string firstName, string lastName, int age, decimal salary) {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Salary = salary;
    }

    public override string ToString() {
        return $"{FirstName} {LastName} receives {Salary:F2} leva.";
    }

    public void IncreaseSalary(decimal percentage) {
        decimal increase = this.Salary * percentage / 100;

        if (this.Age < 30) increase /= 2;
        
        this.Salary += increase;
    }
}