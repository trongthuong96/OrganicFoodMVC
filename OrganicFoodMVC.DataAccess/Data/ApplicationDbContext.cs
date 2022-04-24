using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OrganicFoodMVC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganicFoodMVC.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Brand> Brands { get; set; }
        
        public DbSet<Product> Products { get; set; }
    }
}
