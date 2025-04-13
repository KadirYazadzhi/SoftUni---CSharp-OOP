using System;
using System.Linq;
using System.Reflection;

namespace AuthorProblem;

public class Tracker {
    public void PrintMethodsByAuthor() {
        Type type = typeof(StartUp);
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        foreach (var method in methods) {
            var attributes = method.GetCustomAttributes<AuthorAttribute>();

            foreach (var attribute in attributes) {
                Console.WriteLine($"{method.Name} is written by {attribute.Name}");
            }
        }
    }
}
