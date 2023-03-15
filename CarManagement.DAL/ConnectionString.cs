using CarManagement.DAL.Interfaces;
using Microsoft.Extensions.Configuration;

namespace CarManagement.DAL;

public class ConnectionString : IConnectionString
{
    public ConnectionString(IConfiguration configuration)
    {
        Value = configuration.GetConnectionString("CarManagementDb");
    }

    public string Value { get; }
}
