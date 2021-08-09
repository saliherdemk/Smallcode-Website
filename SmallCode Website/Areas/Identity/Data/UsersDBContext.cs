using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmallCode_Website.Areas.Identity.Data;
using SmallCode_Website.Models;

namespace SmallCode_Website.Data
{
    public class UsersDBContext : IdentityDbContext<User>
    {
        public UsersDBContext(DbContextOptions<UsersDBContext> options)
            : base(options)
        {
        }

        public DbSet<Codes> Codes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
