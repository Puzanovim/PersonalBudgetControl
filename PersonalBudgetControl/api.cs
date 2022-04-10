using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonalBudgetControl.Repositories;


namespace PersonalBudgetControl
{
    class api
    {
        private DaylyStatRepo daylyStatRepo;
        private MonthlyStatRepo monthlyStatRepo;
        public api()
        {
            this.monthlyStatRepo = new MonthlyStatRepo();
        }

        public void CreateNewMonth(List<int> incomes, List<int> expenses)
        {
            DateTime today = new DateTime();
            this.monthlyStatRepo.CreateBackup();
            this.monthlyStatRepo.CreateNewMonth(date: today, incomes: incomes, mandatoryExpenditures: expenses);
            int countDays = DateTime.DaysInMonth(year: today.Year, month: today.Month);
            int oneDayBudget = this.monthlyStatRepo.MonthStat.OneDayBudget;
            this.daylyStatRepo = new DaylyStatRepo(days: countDays, oneDayBudget: oneDayBudget);
        }

        public Dictionary<string, int> GetMonthInfo()
        {
            Dictionary<string, int> monthInfo = new Dictionary<string, int>()
            {
                {"monthNumber",  this.monthlyStatRepo.MonthStat.Month.MonthNumber},
                {"sumIncomes",  this.monthlyStatRepo.MonthStat.SumIncomes},
                {"sumMandatoryExpenses",  this.monthlyStatRepo.MonthStat.SumMandatoryExpenses},
                {"oneDayBudget",  this.monthlyStatRepo.MonthStat.OneDayBudget},
                {"totalExpenses",  this.monthlyStatRepo.MonthStat.TotalExpenses},
                {"accumulations",  this.monthlyStatRepo.MonthStat.Accumulations},
            };
            return monthInfo;
        }

        public void AddIncome(List<int> incomes)
        {
            this.monthlyStatRepo.AddIncome(incomes);
        }

        public void AddMandatoryExpenses(List<int> mandatoryExpenses)
        {
            this.monthlyStatRepo.AddMandatoryExpense(mandatoryExpenses);
        }

        public void AddExpense(DateTime date, int expense)
        {
            this.daylyStatRepo.AddExpense(day: date.Day, expense: expense);
            int newSumExpenses = this.daylyStatRepo.SumExpenses();
            this.monthlyStatRepo.UpdateSumExpenses(newSumExpenses);
        }
    }
}
