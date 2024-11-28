using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using DataAccessLayer;
using System.Configuration;
using Ninject.Modules;

namespace BusinessLogic
{
    public class Logic : IDisposable,ILogic
    {
        private readonly IRepository<Student> _studentRepository;

        public Logic(IRepository<Student> repository)
        {
           _studentRepository = repository;
        }

        public void AddStudent(int id, string name, string speciality, string group)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(speciality) || string.IsNullOrEmpty(group))
            {
                throw new Exception("Одно из полей пустое!");
            }

            Student newStudent = new Student(id, name, speciality, group);
            _studentRepository.Create(newStudent);
        }

        public void RemoveStudent(int id)
        {
            var studentToRemove = _studentRepository.Get(id);
            if (studentToRemove == null)
            {
                throw new Exception("Студент отсутствует в базе данных");
            }

            _studentRepository.Delete(id);
        }

        public void UpdateStudent(int id, string newname, string newSpeciality, string newGroup)
        {
            if (id <= 0)
            {
                throw new Exception("Неверное id");
            }

            var studentToUpdate = _studentRepository.Get(id);
            if (studentToUpdate == null)
            {
                throw new Exception("Студент отсутствует в базе данных");
            }

            if (!string.IsNullOrEmpty(newname))
            {
                studentToUpdate.Name = newname;
            }
            if (!string.IsNullOrEmpty(newSpeciality))
            {
                studentToUpdate.Speciality = newSpeciality;
            }
            if (!string.IsNullOrEmpty(newGroup))
            {
                studentToUpdate.Group = newGroup;
            }

            _studentRepository.Update(studentToUpdate);
        }
        public List<List<string>> GetAllStudents()
        {
            // Получаем всех студентов
            var students = _studentRepository.GetAll();

            // Проверяем, что список студентов не null и не пустой
            if (students == null || !students.Any())
            {
                return new List<List<string>>(); // Возвращаем пустой список, если нет студентов
            }

            // Преобразуем список студентов в список списков строк
            return students.Select(student => new List<string>
            {
                student.Id.ToString(),
                student.Name ?? string.Empty, // Используем ?? для обработки возможного null
                student.Speciality ?? string.Empty,
                student.Group ?? string.Empty
            }).ToList();
        }
        public List<string> GetStudent(int id)
        {
            var student = _studentRepository.Get(id);
            if (student == null)
            {
                throw new ArgumentException("Студент с указанным ID не найден");
            }
            return new List<string>
            {
                student.Id.ToString(),
                student.Name,
                student.Speciality,
                student.Group
            };
        }
        public Dictionary<string, int> GetSpecialityDistribution()
        {
            var students = _studentRepository.GetAll().ToList();
            if (students.Count == 0)
            {
                throw new Exception("Список студентов пуст");
            }

            return students.GroupBy(s => s.Speciality)
                           .ToDictionary(g => g.Key, g => g.Count());
        }

        /// <summary>
        /// Освобождает ресурсы, используемые логикой.
        /// </summary>
        public void Dispose()
        {
            _studentRepository.Dispose();
        }
    }
}
