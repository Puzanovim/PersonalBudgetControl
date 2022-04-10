using System;
using System.Collections.Generic;
using System.Linq;


namespace PersonalBudgetControl.Data
{
    class MonthStat
    {
        private Month currentMonth;

        private List<int> incomes;
        private List<string> incomesDescription;
        private List<int> mandatoryExpenses;
        private List<string> mandatoryExpensesDescription;

        private int sumIncomes = 0;
        private int sumMandatoryExpenses = 0;
        private int sumExpenses = 0;

        private int cleanIncome = 0;
        private int oneDayBudget = 0;
        private int totalExpenses = 0;
        private int accumulations = 0;

        public Month Month => currentMonth;
        public List<int> Incomes => incomes;
        public List<string> IncomesDescription => incomesDescription;
        public List<int> MandatoryExpenses => mandatoryExpenses;
        public List<string> MandatoryExpensesDescription => mandatoryExpensesDescription;
        public int SumIncomes => sumIncomes;
        public int SumMandatoryExpenses => sumMandatoryExpenses;
        public int SumExpenses => sumExpenses;
        public int CleanIncome => cleanIncome;
        public int OneDayBudget => oneDayBudget;
        public int TotalExpenses => totalExpenses;
        public int Accumulations => accumulations;

        private void UpdateData()
        {
            this.sumIncomes = this.incomes.Sum();
            this.sumMandatoryExpenses = this.mandatoryExpenses.Sum();
            this.cleanIncome = this.sumIncomes - this.sumMandatoryExpenses;
            this.oneDayBudget = this.cleanIncome / DateTime.DaysInMonth(year: this.currentMonth.Year, month: this.currentMonth.MonthNumber);
            this.totalExpenses = this.sumMandatoryExpenses + this.sumExpenses;
            this.accumulations = this.sumIncomes - this.totalExpenses;
        }

        public MonthStat(List<int> incomes, List<int> mandatoryExpenditures, Month currentMonth)
        {
            this.currentMonth = currentMonth;
            this.incomes = incomes;
            this.mandatoryExpenses = mandatoryExpenditures;

            UpdateData();
        }

        public void AddIncome(int income)
        {
            this.incomes.Add(income);

            UpdateData();
        }

        public void AddMandatoryExpense(int mandatoryExpense)
        {
            this.mandatoryExpenses.Add(mandatoryExpense);

            UpdateData();
        }

        public void UpdateSumExpenses(int newSumExpenses)
        {
            this.sumExpenses = newSumExpenses;
            this.totalExpenses = this.sumMandatoryExpenses + this.sumExpenses;
            this.accumulations = this.sumIncomes - this.totalExpenses;
        }
    }
}
