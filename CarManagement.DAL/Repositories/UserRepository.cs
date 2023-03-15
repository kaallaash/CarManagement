using System.Data.SqlClient;
using System.Data;
using CarManagement.DAL.Interfaces;
using CarManagement.Models;
using Dapper;
using CarManagement.Models.Authentication;

namespace CarManagement.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly string _connectionString;

    public UserRepository(IConnectionString connectionString)
    {
        _connectionString = connectionString.Value;
    }

    public async Task<UserModel> GetByLoginAsync(LoginModel loginModel)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
        return await dbConnection.QuerySingleOrDefaultAsync<UserModel>(sql, loginModel);
    }

    public async Task<int> RegisterAsync(RegisterModel registerModel)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "INSERT INTO Users (Username, Password, Email, FirstName, LastName)" +
                           " VALUES (@Username, @Password, @Email, @FirstName, @LastName);" +
                           " SELECT CAST(SCOPE_IDENTITY() as int)";
        return await dbConnection.ExecuteScalarAsync<int>(sql, registerModel);
    }

    public async Task<bool> UpdateAsync(RegisterModel registerModel)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "UPDATE Users SET" +
                           " Username = @Username, Password = @Password, Email = @Email, FirstName = @FirstName, LastName = @LastName" +
                           " WHERE Id = @Id";
        var affectedRows = await dbConnection.ExecuteAsync(sql, registerModel);
        return affectedRows > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        using IDbConnection dbConnection = new SqlConnection(_connectionString);
        const string sql = "DELETE FROM Users WHERE Id = @Id";
        var affectedRows = await dbConnection.ExecuteAsync(sql, new { Id = id });
        return affectedRows > 0;
    }
}