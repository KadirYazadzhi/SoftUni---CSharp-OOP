namespace PersonsInfo;

public class Person {
    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName {
        get => firstName;
        private set {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3) {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            firstName = value;
        }
    }

    public string LastName {
        get => lastName;
        private set {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3) {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            lastName = value;
        }
    }

    public int Age {
        get => age;
        private set {
            if (value <= 0) {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }

    public decimal Salary {
        get => salary;
        private set {
            if (value < 650) {
                throw new ArgumentException("Salary cannot be less than 650 leva!");
            }
            salary = value;
        }
    }

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
        decimal increase = salary * percentage / 100;
        if (age < 30) {
            increase /= 2;
        }
        salary = Math.Round(salary + increase, 2, MidpointRounding.AwayFromZero);
    }
}