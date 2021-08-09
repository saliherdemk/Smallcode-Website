using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmallCode_Website.Areas.Identity.Data;
using SmallCode_Website.Data;

[assembly: HostingStartup(typeof(SmallCode_Website.Areas.Identity.IdentityHostingStartup))]
namespace SmallCode_Website.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<UsersDBContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("UsersDBContextConnection")));

                services.AddDefaultIdentity<User>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                } )
                    .AddEntityFrameworkStores<UsersDBContext>();
            });
        }
    }
}