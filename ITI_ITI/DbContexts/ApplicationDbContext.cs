using ITI_ITI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ITI_ITI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> customers { get; set; }
        public DbSet<MyRestaurant> MyRestaurants { get; set; }
    }
}
