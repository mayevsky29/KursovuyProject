using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.EFContext.Data;
using WebLibrary.EFContext.Identity;

namespace WebLibrary.EFContext
{
    public class DataContext : IdentityDbContext<AppUser, AppRole, long, IdentityUserClaim<long>,
            AppUserRole, IdentityUserLogin<long>,
            IdentityRoleClaim<long>, IdentityUserToken<long>>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<UserBook> UserBooks{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AppUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            object p = builder.Entity<UserBook>(userBook =>
            {
                userBook.HasKey(ur => new { ur.UserId, ur.BookId });

                userBook.HasOne(ur => ur.Book)
                    .WithMany(r => r.UserBooks)
                    .HasForeignKey(ur => ur.BookId)
                    .IsRequired();

                userBook.HasOne(ur => ur.User)
                    .WithMany(r => r.UserBooks)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });
        }
    }
}
