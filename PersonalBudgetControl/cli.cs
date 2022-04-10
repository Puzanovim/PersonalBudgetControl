using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonalBudgetControl
{
    class cli
    {
        private static List<int> getValues(string countInputText, string elementInputText)
        {
            Console.Write(countInputText);
            int countElements = int.Parse(Console.ReadLine());
            List<int> elements = new List<int>();
            for (var i = 0; i < countElements; i++)
            {
                Console.Write(elementInputText + (i + 1) + " ");
                elements.Add(int.Parse(Console.ReadLine()));
            }
            return elements;
        }

        private static void printMonthInfo(api api)
        {
            Dictionary<string, int> monthInfo = api.GetMonthInfo();
            Console.WriteLine("---------- Month info ----------");
            Console.WriteLine("Ваши доходы: " + monthInfo["sumIncomes"]);
            Console.WriteLine("Ваши обязательные расходы: " + monthInfo["sumMandatoryExpenses"]);
            Console.WriteLine("Подсчитан бюджет на день: " + monthInfo["oneDayBudget"]);
            Console.WriteLine("Ваши расходы за этот месяц: " + monthInfo["totalExpenses"]);
            Console.WriteLine("Накопления за этот месяц: " + monthInfo["accumulations"]);
            Console.WriteLine("---------- info ----------");
        }

        private static void helpCommand()
        {
            Console.WriteLine("Тебе помогут следующие комманды:");
            Console.WriteLine("S - для создания нового месяца");
            Console.WriteLine("I - для добавления нового дохода");
            Console.WriteLine("M - для добавления нового обязательного расхода");
            Console.WriteLine("E - для добавления нового расхода");
            Console.WriteLine("H - для вывода справочной информации");
            Console.WriteLine("G - для завершения сеанса");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Привет!\nЭто твой личный финансовый помощник");
            bool goodBue = false;
            api api = new api();
            helpCommand();
            while (true)
            {
                if (goodBue)
                    break;
                string input = Console.ReadLine();
                switch (input)
                {
                    case "S":
                        List<int> incomes = getValues(
                            countInputText: "Введите количество источников вашего дохода: ",
                            elementInputText: "Введите доход №"
                        );
                        List<int> expenses = getValues(
                            countInputText: "Введите количество обязательных расходов: ",
                            elementInputText: "Введите обязательный расход №"
                        );
                        api.CreateNewMonth(incomes, expenses);
                        printMonthInfo(api);
                        break;
                    case "I":
                        List<int> newIncomes = getValues(
                            countInputText: "Введите количество новых источников вашего дохода: ",
                            elementInputText: "Введите доход №"
                        );
                        api.AddIncome(newIncomes);
                        printMonthInfo(api);
                        break;
                    case "M":
                        List<int> newMandatoryExpenses = getValues(
                            countInputText: "Введите количество новых обязательных расходов: ",
                            elementInputText: "Введите обязательный расход №"
                        );
                        api.AddMandatoryExpenses(newMandatoryExpenses);
                        printMonthInfo(api);
                        break;
                    case "E":
                        Console.Write("Введите новый расход за сегодня: ");
                        int newExpense = int.Parse(Console.ReadLine());
                        DateTime today = DateTime.Today;
                        api.AddExpense(today, newExpense);
                        printMonthInfo(api);
                        break;
                    case "H":
                        helpCommand();
                        break;
                    case "G":
                        Console.WriteLine("Good bue!");
                        goodBue = true;
                        break;
                }                    
            }
        }
    }
}
