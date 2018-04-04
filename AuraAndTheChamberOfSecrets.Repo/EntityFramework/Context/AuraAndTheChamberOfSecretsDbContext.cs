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

        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<UserOrganization> UserOrganizations { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserOrganization>()
                .HasKey(auo => new { UserId = auo.UserProfileId, auo.OrganizationId });

            builder.Entity<UserOrganization>()
                .HasOne(auo => auo.UserProfile)
                .WithMany(u => u.OrganizationLinks)
                .HasForeignKey(auo => auo.UserProfileId);

            builder.Entity<UserOrganization>()
                .HasOne(auo => auo.Organization)
                .WithMany(o => o.UserLinks)
                .HasForeignKey(auo => auo.OrganizationId);
        }
    }
}
