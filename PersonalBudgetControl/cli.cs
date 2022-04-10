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
                Console.Write(elementInputText + i);
                elements.Add(int.Parse(Console.ReadLine()));
            }
            return elements;
        }

        private static void printMonthInfo(
            string monthName,
            int sumIncomes,
            int sumMandatoryExpenses,
            int oneDayBudget,
            int totalExpenses,
            int accumulations
        )
        {
            Console.WriteLine("---------- " + monthName + " info ----------");
            Console.WriteLine("Ваши доходы: " + sumIncomes);
            Console.WriteLine("Ваши обязательные расходы: " + sumMandatoryExpenses);
            Console.WriteLine("Подсчитан бюджет на день: " + oneDayBudget);
            Console.WriteLine("Ваши расходы за этот месяц: " + totalExpenses);
            Console.WriteLine("Накопления за этот месяц: " + accumulations);
            Console.WriteLine("---------- " + monthName + " info ----------");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool goodBue = false;
            api api = new api();
            while (true)
            {
                if (goodBue)
                    break;
                string input = Console.ReadLine();
                switch (input)
                {
                    case "S":
                        Console.WriteLine("Creating new month");
                        List<int> incomes = getValues(
                            countInputText: "Введите количество источников вашего дохода: ",
                            elementInputText: "Введите доход №"
                        );
                        List<int> expenses = getValues(
                            countInputText: "Введите количество обязательных расходов: ",
                            elementInputText: "Введите обязательный расход №"
                        );
                        api.CreateNewMonth(incomes, expenses);
                        Dictionary<string, object> monthInfo = api.GetMonthInfo();
                        printMonthInfo(
                            monthName: (string) monthInfo["monthName"],
                            sumIncomes: (int) monthInfo["sumIncomes"],
                            sumMandatoryExpenses: (int)monthInfo["sumMandatoryExpenses"],
                            oneDayBudget: (int)monthInfo["oneDayBudget"],
                            totalExpenses: (int)monthInfo["totalExpenses"],
                            accumulations: (int)monthInfo["accumulations"]
                        );
                        break;
                    case "I":
                        Console.WriteLine("Adding income");
                        break;
                    case "M":
                        Console.WriteLine("Adding mandatoryexpenses");
                        break;
                    case "E":
                        Console.WriteLine("Adding expense");
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
