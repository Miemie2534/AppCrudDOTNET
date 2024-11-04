using AppCrudDOTNET.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrudDOTNET.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet <EmerList> EmerList { get; set; }
        public DbSet <Employee> Employee { get; set; }
        public DbSet <Offer> Offer { get; set; }
        public DbSet <Animal> Animal { get; set; }
    }
}
