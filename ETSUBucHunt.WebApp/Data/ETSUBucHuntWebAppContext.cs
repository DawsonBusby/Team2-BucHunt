using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ETSUBucHunt.WebApp.Models;

namespace ETSUBucHunt.WebApp.Data
{
    public class ETSUBucHuntWebAppContext : DbContext
    {
        public ETSUBucHuntWebAppContext (DbContextOptions<ETSUBucHuntWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<ETSUBucHunt.WebApp.Models.Tasks> Tasks { get; set; } = default!;
    }
}
