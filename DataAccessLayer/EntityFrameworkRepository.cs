using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity.SqlServer;
using Model;

namespace DataAccessLayer
{
    public class EntityFrameworkRepository<T> : IStudentRepository
    {
        private Context Context { get; set; } = new Context();

        public IEnumerable<Student> GetAll()
        {
            return Context.Set<Student>().ToList();
        }

        public Student Get(int id)
        {
            return Context.Set<Student>().Find(id);
        }

        public void Create(Student entity)
        {
            Context.Set<Student>().Add(entity);
            Save();
        }

        public void Update(Student entity)
        {
            Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            Save();
        }

        public void Delete(int id)
        {
            var entity = Context.Set<Student>().Find(id);
            if (entity != null)
            {
                Context.Set<Student>().Remove(entity);
                Save();
            }
        }

        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        public void Save()
        {
            Context.SaveChanges();
        }

        /// <summary>
        /// Освобождает ресурсы, используемые репозиторием.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Освобождает неуправляемые (а при необходимости и управляемые) ресурсы.
        /// </summary>
        /// <param name="disposing">Значение true для освобождения управляемых и неуправляемых ресурсов; значение false для освобождения только неуправляемых ресурсов.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context?.Dispose();
            }
        }
    }
}
