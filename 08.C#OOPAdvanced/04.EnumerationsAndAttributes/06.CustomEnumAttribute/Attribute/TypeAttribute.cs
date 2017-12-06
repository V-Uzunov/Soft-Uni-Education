namespace _06.CustomEnumAttribute.Attribute
{
    using System;
    [AttributeUsage(AttributeTargets.Enum, AllowMultiple = true)]
    public class TypeAttribute : Attribute
    {
        public TypeAttribute(string type, string category, string disctiption)
        {
            this.Type = type;
            this.Category = category;
            this.Discription = disctiption;
        }

        public string Type { get; set; }
        public string Category { get; set; }
        public string Discription { get; set; }

        public override string ToString()
        {
            return $"Type = {this.Type}, Description = {this.Discription}";
        }
    }
}
