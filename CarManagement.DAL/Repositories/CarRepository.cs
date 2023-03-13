using CarManagement.DAL.Interfaces;
using CarManagement.Models.Car;
using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CarManagement.DAL.Repositories;

public class CarRepository : ICarRepository
{
    private readonly IDbConnection _dbConnection;

    public CarRepository(string connectionString)
    {
        _dbConnection = new SqlConnection(connectionString);
    }

    public async Task<IEnumerable<CarModel>> GetAllAsync()
    {
        const string sql = "SELECT * FROM Cars";
        return await _dbConnection.QueryAsync<CarModel>(sql);
    }

    public async Task<IEnumerable<CarModel>> GetSomeAsync(int skip, int take)
    {
        const string sql = "SELECT * FROM Cars ORDER BY Id OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY";
        return await _dbConnection.QueryAsync<CarModel>(sql, new { Skip = skip, Take = take });
    }

    public async Task<CarModel> GetByIdAsync(int id)
    {
        const string sql = "SELECT * FROM Cars WHERE Id = @Id";
        return await _dbConnection.QuerySingleOrDefaultAsync<CarModel>(sql, new { Id = id });
    }

    public async Task<int> CreateAsync(CarCreateModel car)
    {
        const string sql = "INSERT INTO Cars (Make, Model, Year, Color) VALUES (@Make, @Model, @Year, @Color); SELECT CAST(SCOPE_IDENTITY() as int)";
        return await _dbConnection.ExecuteScalarAsync<int>(sql, car);
    }

    public async Task<bool> UpdateAsync(CarUpdateModel car)
    {
        const string sql = "UPDATE Cars SET Make = @Make, Model = @Model, Year = @Year, Color = @Color WHERE Id = @Id";
        var affectedRows = await _dbConnection.ExecuteAsync(sql, car);
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        const string sql = "DELETE FROM Cars WHERE Id = @Id";
        var affectedRows = await _dbConnection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }
}