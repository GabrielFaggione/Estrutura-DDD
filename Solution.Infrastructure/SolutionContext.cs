using Microsoft.EntityFrameworkCore;
using Solution.Domain.Entities.TodoAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Infrastructure
{
    public class SolutionContext : DbContext
    {

        public SolutionContext(DbContextOptions<SolutionContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }

    }
}
