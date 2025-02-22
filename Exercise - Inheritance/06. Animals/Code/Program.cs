namespace Animals;

using System;

public class StartUp {
    public static void Main() {
        var animals = new List<Animal>();
        
        while (true) {
            string type = Console.ReadLine();
            if (type == "Beast!") break;

            string[] info = Console.ReadLine()?.Split();
            if (info == null || info.Length < 2) continue;

            try {
                string name = info[0];
                int age = int.Parse(info[1]);
                string gender = info.Length == 3 ? info[2] : "";

                Animal animal = type switch {
                    "Dog" => new Dog(name, age, gender),
                    "Frog" => new Frog(name, age, gender),
                    "Cat" => new Cat(name, age, gender),
                    "Kitten" => new Kitten(name, age),
                    "Tomcat" => new Tomcat(name, age),
                    _ => throw new ArgumentException("Invalid input!")
                };
                
                animals.Add(animal);
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        foreach (var animal in animals) {
            Console.WriteLine(animal);
        }
    }
}
