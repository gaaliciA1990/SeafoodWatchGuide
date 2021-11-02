using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ContosoCrafts.WebSite.Models;

namespace ContosoCrafts.WebSite.Data
{
    /// <summary>
    /// Class for rendering the website and content
    /// </summary>
    public class ContosoCraftsWebSiteContext : DbContext
    {
        /// <summary>
        /// Constructor method for implementing the webpage on startup
        /// </summary>
        /// <param name="options"></param>
        public ContosoCraftsWebSiteContext (DbContextOptions<ContosoCraftsWebSiteContext> options): base(options)
        {

        }

        /// <summary>
        /// Declares getter and setter for the ProductModel
        /// </summary>
        public DbSet<ContosoCrafts.WebSite.Models.ProductModel> ProductModel 
        { 
            get; 
            set;
        }
    }
}
