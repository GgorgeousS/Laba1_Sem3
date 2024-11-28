using Ninject.Activation.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;

namespace ConsoleApp1
{
    public class ConsoleView:IConsoleView
    {
        private readonly ILogic logic;
        public ConsoleView(ILogic logic)
        {
            this.logic = logic;
        }
        public void Start()
        {
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
                        AddStudent();
                        break;
                    case "2":
                        RemoveStudent();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        ListStudents();
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
                        ShowDistribution();
                        break;
                }
            }
            while (command != "6");
        }
        public void AddStudent()
        {
            Console.Write("Введите имя студента: ");
            string name = Console.ReadLine();

            Console.Write("Введите специальность студента: ");
            string speciality = Console.ReadLine();

            Console.Write("Введите группу студента: ");
            string group = Console.ReadLine();

            try
            {
                logic.AddStudent(logic.GetAllStudents().Count(), name, speciality, group);
                Console.WriteLine("Студент успешно добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка! {ex.Message}");
            }

        }
        public void RemoveStudent()
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
        public void UpdateStudent()
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

                    try
                    {
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

        public void ListStudents()
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
        public void ShowDistribution()
        {
            var data = logic.GetSpecialityDistribution();
            // Определяем максимальную ширину диаграммы в символах
            int maxWidth = 40;

            // Находим максимальное значение, чтобы нормализовать длину столбцов
            int maxValue = 0;
            foreach (var value in data.Values)
            {
                if (value > maxValue)
                    maxValue = value;
            }

            // Выводим заголовок
            Console.WriteLine("Гистограмма");

            // Строим каждый элемент диаграммы
            foreach (var entry in data)
            {
                // Нормализуем длину столбца в символах
                int barLength = maxValue > 0 ? (entry.Value * maxWidth) / maxValue : 0;

                // Создаем строку с графическим представлением
                string bar = new string('#', barLength);

                // Печатаем метку и сам столбец
                Console.WriteLine($"{entry.Key.PadRight(10)} | {bar} ({entry.Value})");
            }
        }

    }
}
