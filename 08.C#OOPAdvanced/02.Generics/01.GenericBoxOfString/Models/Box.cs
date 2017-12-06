namespace _01.GenericBoxOfString.Models
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
    {
        private T data;
        
        public Box(T data)
        {
            this.Data = data;
        }

        public T Data { get; private set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Data.GetType().FullName}: {this.Data}");

            return sb.ToString().Trim();
        }
    }
}
