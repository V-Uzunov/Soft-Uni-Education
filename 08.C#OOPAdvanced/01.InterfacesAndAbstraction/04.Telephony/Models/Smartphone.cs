namespace _04.Telephony
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Smartphone : ITelephone, ITelephoneFunc
    {
        private ICollection<string> phoneNumber;
        private ICollection<string> site;

        public Smartphone(ICollection<string> phoneNumber, ICollection<string> site)
        {
            this.PhoneNumber = new List<string>(phoneNumber);
            this.Site = new List<string>(site);
        }

        public ICollection<string> PhoneNumber
        {
            get { return this.phoneNumber; }
            private set { this.phoneNumber = value; }
        }

        public ICollection<string> Site
        {
            get { return this.site; }
            private set { this.site = value; }
        }

        public string Calling(string number)
        {
            if (!number.Any(x => Char.IsDigit(x)))
            {
                return  "Invalid number!";
            }
            else
            {
                return $"Calling... {number}";
            }
        }

        public string Browsing(string url)
        {
            if (url.Any(x => Char.IsDigit(x)))
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {url}!";
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var num in this.PhoneNumber)
            {
                sb.AppendLine(Calling(num));
            }

            foreach (var url in this.Site)
            {
                sb.AppendLine(Browsing(url));
            }

            return sb.ToString().Trim();
        }
    }
}
