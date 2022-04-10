using System;
using System.Collections.Generic;
using PersonalBudgetControl.Data;


namespace PersonalBudgetControl.Repositories
{
    class DaylyStatRepo
    {
        private List<Day> daylyStats;
        public List<Day> DaylyStatsList => daylyStats;

        private void UpdateDaylyStats(int day)
        {
            int saldo = this.daylyStats[day].Saldo;
            int days = this.daylyStats.Count;
            day += 1;
            while (saldo < 0)
            {
                if (day == days)
                    break;
                int next_expense = saldo * -1;
                this.daylyStats[day].AddExpense(next_expense);
                Console.WriteLine("Updated expenses at: " + day);
                saldo = this.daylyStats[day].Saldo;
            }
        }

        public DaylyStatRepo(int days, int oneDayBudget)
        {
            this.daylyStats = new List<Day>();
            for (var i = 0; i < days; i++)
            {
                Day new_day = new Day(i, oneDayBudget);
                this.daylyStats.Add(new_day);
            }
        }

        public void AddExpense(int day, int expense)
        {
            this.daylyStats[day].AddExpense(expense);
            this.UpdateDaylyStats(day);
            Console.WriteLine("Added new expense: " + expense + " to day number " + day);
        }

        public int SumExpenses()
        {
            int sumExpenses = 0;
            foreach(Day day in this.daylyStats)
            {
                sumExpenses += day.SumExpenses;
            }
            return sumExpenses;
        }
    }
}
