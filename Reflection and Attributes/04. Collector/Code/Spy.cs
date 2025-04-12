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

    public string AnalyzeAccessModifiers(string className) {
        Type classType = Type.GetType(className);
        StringBuilder sb = new StringBuilder();

        FieldInfo[] publicFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
        foreach (var field in publicFields) {
            sb.AppendLine($"{field.Name} must be private!");
        }

        MethodInfo[] nonPublicGetters = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(m => m.Name.StartsWith("get_")).ToArray();
        foreach (var getter in nonPublicGetters) {
            sb.AppendLine($"{getter.Name} have to be public!");
        }

        MethodInfo[] publicSetters = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public)
            .Where(m => m.Name.StartsWith("set_")).ToArray();
        foreach (var setter in publicSetters) {
            sb.AppendLine($"{setter.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className) {
        Type classType = Type.GetType(className);
        MethodInfo[] privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in privateMethods) {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();
    }

    public string CollectGettersAndSetters(string className) {
        Type classType = Type.GetType(className);
        MethodInfo[] allMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        StringBuilder sb = new StringBuilder();

        foreach (var method in allMethods) {
            if (method.Name.StartsWith("get_")) {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }
            else if (method.Name.StartsWith("set_")) {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }
        }

        return sb.ToString().Trim();
    }
}
