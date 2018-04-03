using System;
using AuraAndTheChamberOfSecrets.Models;
using AuraAndTheChamberOfSecrets.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuraAndTheChamberOfSecrets.Repo.EntityFramework.Context
{
    public class AuraAndTheChamberOfSecretsDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
        public AuraAndTheChamberOfSecretsDbContext(DbContextOptions<AuraAndTheChamberOfSecretsDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUserOrganization> ApplicationUserOrganizations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUserOrganization>()
                .HasKey(auo => new { auo.ApplicationUserId, auo.OrganizationId });

            builder.Entity<ApplicationUserOrganization>()
                .HasOne(auo => auo.ApplicationUser)
                .WithMany(u => u.OrganizationLinks)
                .HasForeignKey(auo => auo.ApplicationUserId);

            builder.Entity<ApplicationUserOrganization>()
                .HasOne(auo => auo.Organization)
                .WithMany(o => o.UserLinks)
                .HasForeignKey(auo => auo.OrganizationId);
        }
    }
}
