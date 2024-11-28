using System.Configuration.Provider;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using DataAccessLayer;
using Model;
using System.Configuration;

public class DapperRepository<T> : IStudentRepository 
{
    private readonly IDbConnection _connection;
    
    

    public DapperRepository()
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\medka\\Desktop\\3 семак\\AIS\\Laba2Sem3AIS\\Laba2Sem3AIS\\Laba1_Sem3\\Laba1_Sem3\\DataAccessLayer\\Database1.mdf\";Integrated Security=True";
        _connection = new SqlConnection(connectionString);
    }

    public IEnumerable<Student> GetAll()
    {
        var tableName = typeof(T).Name + "s";
        return _connection.Query<Student>($"SELECT * FROM {tableName}");
    }

    public Student Get(int id)
    {
        var tableName = typeof(T).Name + "s";
        return _connection.QuerySingleOrDefault<Student>($"SELECT * FROM {tableName} WHERE Id = @Id", new { Id = id });
    }

    public void Create(Student entity)
    {
        var insertQuery = GenerateInsertQuery();
        _connection.Execute(insertQuery, entity);

    }
    
    public void Update(Student entity)
    {
        var updateQuery = GenerateUpdateQuery();
        _connection.Execute(updateQuery, entity);
    }

    public void Delete(int id)
    {
        var tableName = typeof(T).Name + "s";
        _connection.Execute($"DELETE FROM {tableName} WHERE Id = @Id", new { Id = id });
    }

    private string GenerateInsertQuery()
    {
        var tableName = typeof(T).Name;

        // Опционально добавляем 's' в конце, если нужно. Например, для класса 'Product' будет 'Products'
        // В этом случае условие проверяет, если имя таблицы в единственном числе, добавляем 's'
        if (!tableName.EndsWith("s"))
        {
            tableName += "s";  // Добавляем 's', если имя не заканчивается на 's'
        }

        var columns = string.Join(", ", typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => $"[{p.Name}]"));
        var values = string.Join(", ", typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => $"@{p.Name}"));


        // Формируем и возвращаем SQL-запрос
        return $"INSERT INTO [{tableName}] ({columns}) VALUES ({values})";
    }

    private string GenerateUpdateQuery()
    {
        // Получаем имя таблицы
        var tableName = typeof(T).Name;

        // Добавляем 's' в конец имени таблицы, если оно не заканчивается на 's'
        if (!tableName.EndsWith("s"))
        {
            tableName += "s";  // Добавляем 's', если имя не заканчивается на 's'
        }

        // Экранируем имя таблицы в квадратные скобки
        var tableNameEscaped = $"[{tableName}]";

        // Создаем SET часть запроса, экранируя каждый столбец
        var setClause = string.Join(", ", typeof(T).GetProperties().Where(p => p.Name != "Id").Select(p => $"[{p.Name}] = @{p.Name}"));

        // Формируем запрос с экранированным именем таблицы и столбцов
        return $"UPDATE {tableNameEscaped} SET {setClause} WHERE [Id] = @Id";
    }

    public void Dispose()
    {
        _connection?.Dispose();
    }
}
