using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string Name { get; set; }

    public string[] Fields { get; set; }

    public string CollectGettersAndSetters(string investigatedClass)
    {
        var classType = Type.GetType(investigatedClass);
        var classMethoed = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        var sb = new StringBuilder();

        foreach (var methodInfo in classMethoed.Where(x=> x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
        }
        foreach (var methodInfo in classMethoed.Where(x=> x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass)
    {
        var classType = Type.GetType(investigatedClass);
        var classMethod = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {investigatedClass}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var methodInfo in classMethod)
        {
            sb.AppendLine(methodInfo.Name);
        }

        return sb.ToString().Trim();
    }

    public string  AnalyzeAcessModifiers(string investigatedClass)
    {
        var classType = Type.GetType(investigatedClass);
        var classField = classType.GetFields(BindingFlags.Instance | BindingFlags.Static |
                                             BindingFlags.Public);

        var classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        var classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        var sb = new StringBuilder();
        foreach (var field in classField)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (var privateMethod in classPrivateMethods.Where(x=> x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{privateMethod.Name} have to be public!");
        }
        foreach (var publicMethod in classPublicMethods.Where(x=> x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{publicMethod.Name} have to be private!");
        }

        return sb.ToString().Trim();
    }

    public string StealFieldInfo(string investigatedClass, params string[] requestedFields)
    {
        var classType = Type.GetType(investigatedClass);
        var classField = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic |
                                            BindingFlags.Public);

        var sb = new StringBuilder();

        var classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (FieldInfo fieldInfo in classField.Where(x=> requestedFields.Contains(x.Name)))
        {
            sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }
}