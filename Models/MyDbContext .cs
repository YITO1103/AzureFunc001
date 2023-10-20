
using Entity;
using Microsoft.EntityFrameworkCore;

public class MyDbContext : DbContext
{
    public DbSet<Employee> Blogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //=> optionsBuilder.UseNpgsql(@"Server=sever-pg-a.postgres.database.azure.com;Database=;Port=5432;User Id=postgres;miumiu@0816;Ssl Mode=Require;");
        => optionsBuilder.UseNpgsql(@"Server=sever-pg-a.postgres.database.azure.com;Database=;Port=5432;User Id=postgres;miumiu@0816;");
}
