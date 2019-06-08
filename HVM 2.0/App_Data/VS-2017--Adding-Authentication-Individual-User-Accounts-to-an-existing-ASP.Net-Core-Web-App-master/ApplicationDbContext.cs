using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProgressionTrack.Web.Models;
using ProgressionTrack.Web.Models.CreateGuildViewModels;
using ProgressionTrack.Web.Models.CreateMembers;

namespace ProgressionTrack.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<CreateGuildViewModel> CreateGuildViewModel { get; set; }
        public DbSet<CreateMemberViewModel> CreateMemberViewModel { get; set; }
    }
}
