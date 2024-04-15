using Microsoft.EntityFrameworkCore;
using FogSoft.EF.Library.Entities;
using Task = FogSoft.EF.Library.Entities.Task;
using System.Data.SqlClient;

namespace FogSoft.EF.Library
{
    public class ApplicationContext : DbContext
    {
        readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FogSoft_TaskUsersDB;
                                                Integrated Security=True;Connect Timeout=30;Encrypt=False;
                                                Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;";
        public ApplicationContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try 
            {
                optionsBuilder.UseSqlServer(connectionString);
                Console.WriteLine("Подключение открыто.");
            } 
            catch (SqlException ex) 
            {
                Console.WriteLine(ex.Message);
            }
            
        }
       
        public DbSet<User> Users { get; set; }
        public DbSet<Task> Tasks { get; set; }
    }
}

