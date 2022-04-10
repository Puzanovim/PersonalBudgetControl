using System;
using System.Collections.Generic;
using PersonalBudgetControl.Data;


namespace PersonalBudgetControl.Repositories
{
    class MonthlyStatRepo
    {
        private Dictionary<Month, MonthStat> monthlyStatsHistory;
        private MonthStat currentMonthStats;
        public Dictionary<Month, MonthStat> History => monthlyStatsHistory;
        public MonthStat MonthStat => currentMonthStats;

        public MonthlyStatRepo()
        {
            this.monthlyStatsHistory = new Dictionary<Month, MonthStat>();
        }

        public MonthStat CreateNewMonth(DateTime date, List<int> incomes, List<int> mandatoryExpenditures)
        {
            Month currentMonth = new Month(date);
            this.currentMonthStats = new MonthStat(incomes, mandatoryExpenditures, currentMonth);
            return this.currentMonthStats;
        }

        public Dictionary<Month, MonthStat> CreateBackup()
        {
            if (this.currentMonthStats != null)
            {
                this.monthlyStatsHistory.Add(this.currentMonthStats.Month, this.currentMonthStats);
            }
                return this.monthlyStatsHistory;
        }

        public void AddIncome(List<int> incomes)
        {
            foreach (int income in incomes)
                this.currentMonthStats.AddIncome(income);
        }

        public void AddMandatoryExpense(List<int> mandatoryExpenses)
        {
            foreach (int expense in mandatoryExpenses)
                this.currentMonthStats.AddMandatoryExpense(expense);
        }

        public void UpdateSumExpenses(int newSumExpenses)
        {
            this.currentMonthStats.UpdateSumExpenses(newSumExpenses);
        }
    }
}
