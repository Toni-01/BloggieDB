using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //seed roles: user, admin, super-admin
            var adminRoleId = "a9f0dfe7-f0e8-438b-a18a-1e3f536f9a59";
            var superAdminRoleId = "97cb483c-60ac-489f-9657-aabf435b324e";
            var userRoleId = "1e46917a-e4a7-416d-ab22-5a55015140eb";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName= "Admin",
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId
                },
                new IdentityRole {

                    Name = "SuperAdmin",
                    NormalizedName = "SuperAdmin",
                    Id = superAdminRoleId,
                    ConcurrencyStamp = superAdminRoleId
                },
                new IdentityRole {

                     Name = "User",
                    NormalizedName = "USer",
                    Id = userRoleId,
                    ConcurrencyStamp = userRoleId
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);


            //seed super-admin
            var superAdminId = "a41ff8cc-eade-464b-8849-1ea98eecc307";
            var superAdminUser = new IdentityUser
            {
                UserName = "superadmin@blogie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper(),
                Id = superAdminId,

                PasswordHash = "AQAAAAIAAYagAAAAEM/eoEgrY7ruAApd8/RsmsMCmuK6xJy6H9EBJUB1LCFqdbiP5TdADF3g1SD7ow1ZYA==",

                SecurityStamp = superAdminId,
                ConcurrencyStamp = superAdminId
            };

            superAdminUser.PasswordHash = "AQAAAAIAAYagAAAAEM/eoEgrY7ruAApd8/RsmsMCmuK6xJy6H9EBJUB1LCFqdbiP5TdADF3g1SD7ow1ZYA==";


            builder.Entity<IdentityUser>().HasData(superAdminUser);

            //add all the roles to super-admin
            var superAdminRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    RoleId = adminRoleId,
                    UserId = superAdminId
                },
                 new IdentityUserRole<string>
                {
                    RoleId = superAdminRoleId,
                    UserId = superAdminId
                },
                  new IdentityUserRole<string>
                {
                    RoleId = userRoleId,
                    UserId = superAdminId
                },
            };

            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }
    }
}
