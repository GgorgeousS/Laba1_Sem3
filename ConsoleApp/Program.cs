using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using System.Drawing;
using Spectre.Console;
using static System.Runtime.InteropServices.JavaScript.JSType;
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
                Console.WriteLine($"\nВведите команду: \n-------------------------------\n1.Добавить студента " +
                    $"\n2.Удалить студента \n3.Обновить студента " +
                    $"\n4.Список студентов \n5.Вывести гистограмму \n6.Завершить программу\n-------------------------------");
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
                        
                        try
                        {
                            var TryData = logic.GetSpecialityDistribution();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка!Сообщение ошибки: {ex.Message}");
                            break;
                        }
                        var data = logic.GetSpecialityDistribution();
                        ShowDistribution(data);
                        break;
                }
            }
            while (command != "6");

            /// <summary>
            /// Добавление студента(Консоль)
            /// </summary>
            /// <param name="logic">Бизнес логика</param>

            static void AddStudent(Logic logic)
            {
                Console.Write("Введите имя студента: ");
                string name = Console.ReadLine();

                Console.Write("Введите специальность студента: ");
                string speciality = Console.ReadLine();

                Console.Write("Введите группу студента: ");
                string group = Console.ReadLine();

                try { 
                    logic.AddStudent(logic.GetAllStudents().Count(), name, speciality, group);
                    Console.WriteLine("Студент успешно добавлен!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка! {ex.Message}");
                }
                
            }

            /// <summary>
            /// Удаления студента(Консоль)
            /// </summary>
            /// <param name="logic">Бизнес логика</param>

            static void RemoveStudent(Logic logic)
            {
                if (logic.GetAllStudents().Count() == 0)
                {
                    Console.WriteLine("Ошибка! Список студентов пуст!");
                    return;
                }
                else
                {
                    Console.WriteLine("Введите id студента для удаления");

                    // Вывод списка студентов для выбора
                    foreach (var student in logic.GetAllStudents())
                    {
                        Console.WriteLine($"Номер {student[0]}, Имя:{student[1]} Специальность:{student[2]} Группа:{student[3]}");
                    }

                    int chosenid;

                    if (int.TryParse(Console.ReadLine(), out chosenid))
                    {
                        try
                        {
                            // Удаление студента по выбранному ID
                            logic.RemoveStudent(chosenid);
                            Console.WriteLine("Студент удален.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка! {ex.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ошибка! Введено некорректное значение. Пожалуйста, введите число.");
                    }
                }
            }
            /// <summary>
            /// Обновление студента(Консоль)
            /// </summary>
            /// <param name="logic">Бизнес логика</param>
            static void UpdateStudent(Logic logic)
            {
                Console.WriteLine("Выберите номер студента для изменения:");
                if (logic.GetAllStudents().Count == 0)
                {
                    Console.WriteLine("Сипсок студентов пуст!");
                    return;
                }
                else
                {
                    foreach (var student in logic.GetAllStudents())
                    {
                        Console.WriteLine($"Номер {student[0]}, Имя:{student[1]} Специальность:{student[2]} Группа:{student[3]}");
                    }
                    int chosenid;

                    if (int.TryParse(Console.ReadLine(), out chosenid))
                    {
                        Console.Write("Введите новое имя студента: ");
                        string newname = Console.ReadLine();

                        Console.Write("Введите новую специальность: ");
                        string newspeciality = Console.ReadLine();

                        Console.Write("Введите новую группу: ");
                        string newgroup = Console.ReadLine();

                        try { 
                            logic.UpdateStudent(chosenid, newname, newspeciality, newgroup);
                            Console.WriteLine("Студент Обновлён!");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Ошибка! {ex.Message}");
                            return;
                        }
                        
                    }
                }
            }
            /// <summary>
            /// Вывод списка студентов(Консоль)
            /// </summary>
            /// <param name="logic">Бизнес логика</param>
            static void ListStudents(Logic logic)
            {
                Console.WriteLine("Список студентов:");
                if (logic.GetAllStudents().Count > 0)
                {
                    foreach (var student in logic.GetAllStudents())
                    {
                        Console.WriteLine($"Номер: {student[0]} Имя: {student[1]}, Специальность: {student[2]}, Группа: {student[3]}");
                    }
                }
                else
                {
                    Console.WriteLine("Список пуст!");
                }
            }
            /// <summary>
            /// Вывод гистаграммы(Консоль)
            /// </summary>
            /// <param name="logic">Бизнес логика</param>
            static void ShowDistribution(Dictionary<string, int> data)
            {
                var chart = new BarChart().Width(40).Label("[green bold]Гистограмма[/]");
                foreach (var entry in data)
                {
                    chart.AddItem(entry.Key, entry.Value, Spectre.Console.Color.DarkRed);
                }
                AnsiConsole.Write(chart);
            }
        }
    }
}
