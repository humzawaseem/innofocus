using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class InnofocusContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public InnofocusContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("Default"));
        }

        public virtual DbSet<Hiker> Hikers { get; set; }
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }
        
        

    }
}
