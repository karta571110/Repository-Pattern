using Microsoft.EntityFrameworkCore;
using System;
using EntityModels.Models;
namespace Service
{
    public class RPDbContext:DbContext
    {
        public RPDbContext(DbContextOptions<RPDbContext> options):base(options){}

        public DbSet<merch> merches { get; set; }
        public DbSet<whatever> whatevers { get; set; }
    }
}
