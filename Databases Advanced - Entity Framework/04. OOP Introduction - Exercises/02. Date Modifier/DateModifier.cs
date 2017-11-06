namespace _02.Date_Modifier
{
    using System;
    using System.Globalization;

    public class DateModifier
    {
        private string firstDate;
        private string secondDate;

        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }

        public string FirstDate { get; set; }

        public string SecondDate { get; set; }

        public int CalculateDaysDifference()
        {
            var format = "yyyy MM dd";
            var firstDateToDate = DateTime.ParseExact(this.FirstDate, format, CultureInfo.InvariantCulture);
            var secondDateToDate = DateTime.ParseExact(this.SecondDate, format, CultureInfo.InvariantCulture);

            var daysDifference = (int)Math.Abs((firstDateToDate - secondDateToDate).TotalDays);
            return daysDifference;
        }
    }
}