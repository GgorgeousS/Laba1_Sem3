using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Drawing;
using Spectre.Console;
namespace Laba1_Sem3

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Logic logic = new Logic();
            string command;
            do
            {
                Console.WriteLine($"\nВведите команду: 1.Добавить студента, 2.Удалить студента, 3.Обновить студента, 4.Список студентов, 5.Вывести гистограмму, 6.Завершить программу");
                command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "1":
                        AddStudent(logic);
                        break;
                    case "2":
                        RemoveStudent(logic);
                        break;
                    case "3":
                        UpdateStudent(logic);
                        break;
                    case "4":
                        ListStudents(logic);
                        break;
                    case "5":
                        var data = logic.GetSpecialityDistribution();
                        ShowDistribution(data);
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                }
            }
            while(true);

        }
    }
}
