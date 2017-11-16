namespace _05.DateModifier
{
    using System;

    public class DateModifier
    {
        public string FirstDate { get; set; }
        public string SecondDate { get; set; }

        public double CalculateDifferenceBetweenTwoDates()
        {
            var first = DateTime.Parse(FirstDate);
            var second = DateTime.Parse(SecondDate);

            var res =Math.Abs((second - first).TotalDays);

            return res;
        }
    }
}
