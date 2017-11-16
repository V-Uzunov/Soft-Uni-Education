namespace _02BlackBoxInteger
{
    using System;
    using System.Reflection;
    using System.Text;

    public class Engine
    {
        public string Run(Type type)
        {
            string inputLine;

            var classInstance = Activator.CreateInstance(type, true);
            var fields = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic);
            var field = fields[0];

            var sb = new StringBuilder();

            while ((inputLine = Console.ReadLine()) != "END")
            {
                var tokens = inputLine.Split('_');
                var command = tokens[0];
                var number = int.Parse(tokens[1]);

                var method = typeof(BlackBoxInt).GetMethod(command,
                    BindingFlags.Instance 
                    | BindingFlags.Static
                    | BindingFlags.Public 
                    | BindingFlags.NonPublic);

                method.Invoke(classInstance, new object[] { number });
                
                sb.AppendLine(field.GetValue(classInstance).ToString());

                
            }
            return sb.ToString().Trim();
        }
    }
}
