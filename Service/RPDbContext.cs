using Microsoft.EntityFrameworkCore;
using System;

namespace Service
{
    public class RPDbContext:DbContext
    {
        public RPDbContext(DbContextOptions<RPDbContext> options):base(options)
        {

        }
    }
}
