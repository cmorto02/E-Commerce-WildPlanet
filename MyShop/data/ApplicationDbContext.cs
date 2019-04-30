using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using Microsoft.EntityFrameworkCore;
using MyShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }


        //public DbSet<ApplicationUser> ApplicationUser { get; set; }

        //public DbSet<IdentityUserClaim<string>> IdentityUserClaim { get; set; }

        //public DbSet<IdentityUserRole<string>> IdentityUserRoles { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<IdentityUserRole<Guid>>().HasKey(p => new { p.UserId, p.RoleId });
        //modelBuilder.Entity<IdentityUserClaim<string>>().HasKey(p => new { p.Id });

        //}
    }
}
