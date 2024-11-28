using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface IConsoleView
    {
        /// <summary>
        /// Запускает цикл работы do while
        /// </summary>
        void Start();
        /// <summary>
        /// Добавляет нового студента на основе введенных данных.
        /// </summary>
        void AddStudent();
        /// <summary>
        /// Удаляет студента на основе введенного номера.
        /// </summary>
        void RemoveStudent();
        /// <summary>
        /// Обновляет данные студента на основе введенного номера.
        /// </summary>
        void UpdateStudent();
        /// <summary>
        /// Отображает список всех студентов.
        /// </summary>
        void ListStudents();
        /// <summary>
        /// Показывает распределение студентов по специальностям в виде гистограммы.
        /// </summary>
        void ShowDistribution();
    }
}
