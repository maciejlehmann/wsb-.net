using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesDish.Models;

namespace Restuarant.Data
{
    public class RestuarantContext : DbContext
    {
        public RestuarantContext (DbContextOptions<RestuarantContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesDish.Models.Dish> Dish { get; set; } = default!;
    }
}
