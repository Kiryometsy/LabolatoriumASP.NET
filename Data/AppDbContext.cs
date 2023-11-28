using Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        public DbSet<ContactEntity> Contacts { get; set; }
        public DbSet<OrganizationEntity> Organizations { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            PasswordHasher<IdentityUser> ph = new PasswordHasher<IdentityUser>();

            var user = new IdentityUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = "adam",
                NormalizedUserName = "ADAM",
                Email = "adam@wsei.edu.pl",
                NormalizedEmail = "ADAM@WSEI.EDU.PL",
                EmailConfirmed = true,
            };

            user.PasswordHash = ph.HashPassword(user, "1234Ab!");

            modelBuilder.Entity<IdentityUser>()
                .HasData(
                        user
                    );

            var adminRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            adminRole.ConcurrencyStamp = adminRole.Id;

            modelBuilder.Entity<IdentityRole>()
                .HasData(
                    adminRole
                );

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasData(
                new IdentityUserRole<string>()
                {
                    RoleId = adminRole.Id,
                    UserId = user.Id,
                }
                );

            modelBuilder.Entity<ContactEntity>()
                .HasOne(c => c.Organization)
                .WithMany(o => o.Contacts)
                .HasForeignKey(c => c.OrganizationId);

            modelBuilder.Entity<OrganizationEntity>()
                .HasData(
                    new OrganizationEntity()
                    {
                        Id = 1,
                        Name = "WSEI",
                        Description = "Uczelnia wyższa w Krakowie"
                    }
                );

            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() {
                    ContactId = 1,
                    Name = "Adam",
                    Email = "adam@wsei.edu.pl",
                    Phone = "127813268163",
                    Birth = new DateTime(2000, 10, 10)
                    , OrganizationId = 1 },
                new ContactEntity() {
                    ContactId = 2, 
                    Name = "Ewa", 
                    Email = "ewa@wsei.edu.pl", 
                    Phone = "293443823478", 
                    Birth = new DateTime(1999, 8, 10), 
                    OrganizationId = 1 }
            );

            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Address)
                .HasData(
                    new {
                        OrganizationEntityId = 1,
                        City = "Kraków", 
                        Street = "Św.Filipa 17", 
                        PostalCode = "31-150"
                    }
                );
        }
    }
}
