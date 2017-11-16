namespace _01HarestingFields.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Commands
    {
        public string GetAllFields(string commandForFields)
        {
            var classType = Type.GetType(commandForFields);
            var classField = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            var sb = new StringBuilder();
            foreach (var field in classField)
            {
                var isFamily = field.IsFamily;
                if (isFamily)
                {
                    sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
                }
                else
                {
                    var fieldAttributes = field.Attributes.ToString().ToLower();
                    sb.AppendLine($"{fieldAttributes} {field.FieldType.Name} {field.Name}");
                }
            }
            return sb.ToString().Trim();
        }

        public string GetPublicFields(string commandForFields)
        {
            var classType = Type.GetType(commandForFields);
            var classField = classType.GetFields(BindingFlags.Instance | BindingFlags.Public);

            var sb = new StringBuilder();            
            foreach (var field in classField)
            {
                var fieldAttributes = field.Attributes.ToString().ToLower();
                sb.AppendLine($"{fieldAttributes} {field.FieldType.Name} {field.Name}");
            }
            return sb.ToString().Trim();
        }

        public string GetProtectedFields(string commandForFields)
        {
            var classType = Type.GetType(commandForFields);
            var classField = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsFamily);

            var sb = new StringBuilder();
            foreach (var field in classField)
            {
                sb.AppendLine($"protected {field.FieldType.Name} {field.Name}");
            }
            return sb.ToString().Trim();
        }

        public string GetPrivateFields(string commandForFields)
        {
            var classType = Type.GetType(commandForFields);
            var classField = classType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).Where(x => x.IsPrivate);

            var sb = new StringBuilder();
            foreach (var field in classField)
            {
                var fieldAttributes = field.Attributes.ToString().ToLower();
                sb.AppendLine($"{fieldAttributes} {field.FieldType.Name} {field.Name}");
            }
            return sb.ToString().Trim();
        }
    }
}
