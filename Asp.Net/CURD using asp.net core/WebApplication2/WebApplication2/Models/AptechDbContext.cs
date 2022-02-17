using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class AptechDbContext:DbContext
    {
        public AptechDbContext(DbContextOptions<AptechDbContext> options):base(options)
        { 
        }

        public DbSet<Student> Students { get; set; }

    }
}
