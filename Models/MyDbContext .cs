using System;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using Entity;
using Microsoft.Extensions.Configuration;
public class MyDbContext : DbContext
{
    public MyDbContext() : base(GetConnectionString())
    {
    }

    private static string GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        return configuration["DbConnectionString"];
    }

    public DbSet<Employee> Employees { get; set; }
}
