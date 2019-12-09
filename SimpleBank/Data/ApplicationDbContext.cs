using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleBank.Data.Entities;

namespace SimpleBank.Data
{
    public class ApplicationDbContext : IdentityDbContext<BankUser>
    {
        IHttpContextAccessor _httpContextAccessor;
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            BankUser appUser = new BankUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                FirstName = "admin",
                LastName = "admin",
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = false,
                IsActive = true
            };



            BankUser user1 = new BankUser
            {
                UserName = "john",
                Email = "john@gmail.com",
                NormalizedEmail = "john@gmail.com".ToUpper(),
                NormalizedUserName = "john_sm".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = false,
                FirstName = "John",
                LastName = "Smith",
                IsActive = true
            };
            BankUser user2 = new BankUser
            {
                UserName = "daniel",
                Email = "daniel@gmail.com",
                NormalizedEmail = "daniel@gmail.com".ToUpper(),
                NormalizedUserName = "daniel_mc".ToUpper(),
                TwoFactorEnabled = false,
                EmailConfirmed = true,
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = false,
                FirstName = "Daniel",
                LastName = "McCadole",
                IsActive = true
            };

            PasswordHasher<BankUser> ph = new PasswordHasher<BankUser>();
            appUser.PasswordHash = ph.HashPassword(appUser, "P@ssW0rd!");
            user1.PasswordHash = ph.HashPassword(user1, "P@ssW0rd!");
            user2.PasswordHash = ph.HashPassword(user2, "P@ssW0rd!");

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Name = "User", NormalizedName = "USER" }
            );

            modelBuilder.Entity<BankUser>().HasData(
                appUser,
                user1,
                user2
            );


        }
        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeSaving();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                if (entry.Entity is ITrackable track)
                {
                    var now = DateTime.UtcNow;
                    var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            track.LastUpdatedAt = now;
                            track.LastUpdatedBy = user;
                            break;

                        case EntityState.Added:
                            track.CreatedAt = now;
                            track.CreatedBy = user;
                            track.LastUpdatedAt = now;
                            track.LastUpdatedBy = user;
                            break;
                    }
                }
            }
        }

        private string GetCurrentUser()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            string username = String.Empty;
            if (httpContext != null)
            {
                 username = httpContext.User.Identity.Name;
            }

            return username;
        }
    }
}
