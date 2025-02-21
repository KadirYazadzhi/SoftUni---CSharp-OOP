using System.Text;

namespace Person;

public class Person {
    public string Name { get; private set; }
    public int Age { get; private set; }

    public Person(string name, int age) {
        Name = name;
        Age = age;
    }

    public override string ToString() {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(String.Format("{0} -> ", this.GetType().Name));
        stringBuilder.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));
        
        return stringBuilder.ToString();
    }
}