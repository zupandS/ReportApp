using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Report.Core.Entities;

namespace Report.Infrastructure
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users => Set<User>();

        public DbSet<Record> Records => Set<Record>();

        public DataContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}