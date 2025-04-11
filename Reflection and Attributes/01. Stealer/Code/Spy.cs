using System;
using System.Text;
using System.Reflection;

namespace Stealer;
public class Spy {
    public string StealFieldInfo(string className, string[] fields) {
        Type classType = Type.GetType(className);
        FieldInfo[] allFields = classType.GetFields(
            BindingFlags.Instance | BindingFlags.Static | 
            BindingFlags.NonPublic | BindingFlags.Public);

        object classInstance = Activator.CreateInstance(classType);
        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"Class under investigation: {className}");

        foreach (var field in allFields) {
            if (fields.Contains(field.Name)) {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
        }

        return sb.ToString().Trim();
    }
}
