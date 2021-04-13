using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MonitorsWEB.Models;

namespace MonitorsWEB.Data
{
    public class MonitorsWEBContext : DbContext
    {
        public MonitorsWEBContext (DbContextOptions<MonitorsWEBContext> options)
            : base(options)
        {
        }

        public DbSet<MonitorsWEB.Models.Monitor> Monitor { get; set; }

        public DbSet<MonitorsWEB.Models.Manufacturer> Manufacturer { get; set; }
    }
}
