using Microsoft.EntityFrameworkCore;
using System;
using Service.Models;
namespace Service
{
    public class RPDbContext:DbContext
    {
        public RPDbContext(DbContextOptions<RPDbContext> options):base(options){}

        public DbSet<merch> merches { get; set; }
    }
}
