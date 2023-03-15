using CarManagement.DAL.Interfaces;
using CarManagement.Models.Car;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CarManagement.DAL.Repositories;

public class CarRepository : ICarRepository
{
    private readonly string _connectionString;

    public CarRepository(IConnectionString connectionString)
    {
        _connectionString = connectionString.Value;
    }

    public async Task<IEnumerable<CarModel>> GetAllAsync()
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "SELECT * FROM Cars";
        return await dbConnection.QueryAsync<CarModel>(sql);
    }

    public async Task<IEnumerable<CarModel>> GetSomeAsync(int skip, int take)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "SELECT * FROM Cars ORDER BY Id OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
        return await dbConnection.QueryAsync<CarModel>(sql, new { Skip = skip, Take = take });
    }

    public async Task<CarModel> GetByIdAsync(int id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "SELECT * FROM Cars WHERE Id = @Id";
        return await dbConnection.QuerySingleOrDefaultAsync<CarModel>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(CarCreateModel car)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "INSERT INTO Cars (Make, Model, Year, Price) VALUES (@Make, @Model, @Year, @Price);" +
                           " SELECT CAST(SCOPE_IDENTITY() as int)";
        return await dbConnection.ExecuteScalarAsync<int>(sql, car);
    }

    public async Task<bool> UpdateAsync(CarUpdateModel car)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "UPDATE Cars SET Make = @Make, Model = @Model, Year = @Year, Price = @Price WHERE Id = @Id";
        var affectedRows = await dbConnection.ExecuteAsync(sql, car);
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "DELETE FROM Cars WHERE Id = @Id";
        var affectedRows = await dbConnection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }
}