using Dependencias.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Dependencias.Data;

public class MainContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Carrito> ShoppingCart { get; set; }

    public MainContext(DbContextOptions<MainContext> dbContext) : base(dbContext)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User()
        {
            UserName = "Admin",
            Password = "Admin123"
        }
            );

        using (SqlConnection conn = new(""))
        {

            SqlTransaction transaction = conn.BeginTransaction();

            try
            {

                SqlCommand cmd = conn.CreateCommand();
                cmd.Transaction = transaction;
                cmd.CommandText = File.ReadAllText("DATABASE_SCRIPT.sql");
                cmd.ExecuteNonQuery();

                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
            }

        }
    }
}
