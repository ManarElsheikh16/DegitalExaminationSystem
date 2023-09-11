using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using DigitalExaminationSys.Config;
using DigitalExaminationSys.Models;
using DigitalExaminationSys.Profiles;
using DigitalExaminationSys.Services;
using DigitalExaminationSys.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DigitalExaminationSys
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

          

           // Configure AutoFacModule
              builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(opt =>
            opt.RegisterModule(new AutoFacModule()));


            //Register AutoMapper
            builder.Services.AddAutoMapper(typeof(ProfessorProfile).Assembly);
            builder.Services.AddAutoMapper(typeof(StudentProfile).Assembly);




            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
            .AddEntityFrameworkStores<Context>();

            var app = builder.Build();

         


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}