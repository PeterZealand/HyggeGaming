using HyggeGaming.Models;
using HyggeGaming.Services.EFService;
using HyggeGaming.Services.Interfaces;
using Microsoft.Extensions.Hosting;

namespace HyggeGaming
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<HGDBContext>();
            builder.Services.AddTransient<IAssignmentService, EFAssignmentService>();
            builder.Services.AddTransient<IDevTeamService, EFDevTeamService>();
            builder.Services.AddTransient<IEmployeeService, EFEmployeeService>();
            builder.Services.AddTransient<IGameService, EFGameService>();
            builder.Services.AddTransient<IRoleService, EFRoleService>();
            builder.Services.AddTransient<ICityService, EFCityService>();

            // Session services:
            ////Bruges til at lagre session i memory
            builder.Services.AddDistributedMemoryCache();

            ////Giver options/muligheder for hvordan vi vil ops�tte vores session
            builder.Services.AddSession(options =>
            {
                ////Stopper session efter 30 min inaktivitet
                options.IdleTimeout = TimeSpan.FromMinutes(30);

                ////Lagre session ID - holder brugeren logged in
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //Skal bruges for at session virker
            app.UseSession();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
