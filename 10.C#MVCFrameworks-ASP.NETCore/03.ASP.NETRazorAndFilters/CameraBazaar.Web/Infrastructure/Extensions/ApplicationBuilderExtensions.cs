namespace CameraBazaar.Web.Infrastructure.Extensions
{
    using System.Threading.Tasks;
    using Data;
    using Data.Models;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using GlobalConstants;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CameraBazaarDbContext>().Database.Migrate();

                var user= serviceScope.ServiceProvider.GetService<UserManager<User>>();
                var role= serviceScope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

                Task
                    .Run(async () =>
                    {
                        var adminName = GlobalConstants.AdministratorRoleName;

                        var roleExist =await role.RoleExistsAsync(adminName);

                        if (!roleExist)
                        {
                            await role.CreateAsync(new IdentityRole
                            {
                                Name = adminName
                            });
                        }

                        var userName = "admin@admin.bg";

                        var adminUser = await user.FindByNameAsync(userName);

                        if (adminUser == null)
                        {
                            adminUser = new User
                            {
                                UserName = userName,
                                Email = userName
                            };

                            await user.CreateAsync(adminUser, "Admin12");

                            await user.AddToRoleAsync(adminUser, adminName);
                        }
                    })
                    .Wait();

                Task
                    .Run(async () =>
                    {
                        var loggedInUser = GlobalConstants.LoggedInUser;

                        var roleExist = await role.RoleExistsAsync(loggedInUser);

                        if (!roleExist)
                        {
                            await role.CreateAsync(new IdentityRole
                            {
                                Name = loggedInUser
                            });
                        }
                    })
                    .Wait();
            }

            return app;
        }
    }
}