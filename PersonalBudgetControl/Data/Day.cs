using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetControl.Data
{
    class Day
    {
        private int dayNumber;
        private int sumExpenses = 0;
        private int budget;
        private int saldo;

        public int DayNumber => dayNumber;
        public int SumExpenses => sumExpenses;
        public int Budget => budget;
        public int Saldo => saldo;

        public Day(int dayNumber, int budget)
        {
            this.dayNumber = dayNumber;
            this.budget = budget;
            this.saldo = this.budget;
        }

        public void AddExpense(int expense)
        {
            this.sumExpenses += expense;
            this.saldo -= expense;
        }
    }
}
