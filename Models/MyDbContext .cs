
using Entity;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseNpgsql(@"Server=sever-pg-a.postgres.database.azure.com;Database=;Port=5432;User Id=postgres;miumiu@0816;Ssl Mode=Require;");
        //=> optionsBuilder.UseNpgsql(@"Host=sever-pg-a.postgres.database.azure.com;Username=postgres;Password=miumiu@0816;Database=postgres;SSL Mode=Prefer;");
        => optionsBuilder.UseNpgsql  (@"Server=sever-pg-a.postgres.database.azure.com;Database=;Port=5432;User Id=postgres;Password=miumiu@0816;Ssl Mode=Require;");




        //=> optionsBuilder.UseNpgsql(@"Server=sever-pg-a.postgres.database.azure.com;Database=;Port=5432;User Id=postgres;miumiu@0816;");
}
