using System;


namespace PersonalBudgetControl.Data
{
    class Month
    {
        private int month;
        private int year;

        public string MonthName => month.ToString("MMMM");
        public int MonthNumber => month;
        public int Year => year;

        public Month(DateTime date)
        {
            this.month = date.Month;
            this.year = date.Year;
        }

        public string GetFullMonthName()
        {
            return this.month.ToString("MMMM") + " " + this.year.ToString("yyyy");
        }
    }
}
