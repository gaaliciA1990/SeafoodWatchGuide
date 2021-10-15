using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Data
{
    public class ContosoCraftsWebSiteContext : DbContext
    {
        public ContosoCraftsWebSiteContext (DbContextOptions<ContosoCraftsWebSiteContext> options)
            : base(options)
        {
        }

        public DbSet<ContosoCrafts.WebSite.Models.ProductModel> ProductModel { get; set; }
    }
}
