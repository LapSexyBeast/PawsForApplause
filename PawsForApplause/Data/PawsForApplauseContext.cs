using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PawsForApplause.Models;

namespace PawsForApplause.Data
{
    public class PawsForApplauseContext : DbContext
    {
        public PawsForApplauseContext (DbContextOptions<PawsForApplauseContext> options)
            : base(options)
        {
        }

        public DbSet<PawsForApplause.Models.Show> Show { get; set; } = default!;
    }
}
