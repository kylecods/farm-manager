using DataManagement.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositories;
using Repositories.Mappers;
using Serilog;
using Services;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace DataManagement
{
    public class Startup
    {
        public IConfiguration Configuration;
        public IWebHostEnvironment Environment;
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var settings = new AppSettings();

            ConfigurationBinder.Bind(Configuration.GetSection("AppSettings"), settings);

            services.AddSingleton(s => settings);

            services.AddAutoMapper(config =>
            {
                config.AddProfile<FactoryMapper>();
                config.AddProfile<WorkerMapper>();
                config.AddProfile<FactoryCollectionMapper>();
                config.AddProfile<WorkerTrackerMapper>();
                config.AddProfile<AccountsMapper>();
            });

            services.AddControllersWithViews();

            services.AddRazorPages();

            services.AddDbContext<FarmDbContext>(options =>
            {
                options.UseSqlServer(settings.ConnectionString);
            });

            services.AddHostedService<HostedServices.DatabaseHostedService>();

            services.AddDbContext<DataManagementContext>(options => {

                //Dan Mallot talk NDC Conference, https://www.youtube.com/watch?v=ZKVXl2640ps
                options.UseSqlServer(settings.ConnectionString, sqlServerOptionsAction =>
                {
                    sqlServerOptionsAction.EnableRetryOnFailure(maxRetryCount: 4, maxRetryDelay: System.TimeSpan.FromSeconds(1), errorNumbersToAdd: new int[] { });
                });

                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

                if (Environment.IsDevelopment())
                {
                    options.EnableDetailedErrors();
                    options.EnableSensitiveDataLogging();
                    options.ConfigureWarnings(warningsAction =>
                    {
                        warningsAction.Log(new EventId[]
                        {
                            CoreEventId.FirstWithoutOrderByAndFilterWarning,
                            CoreEventId.RowLimitingOperationWithoutOrderByWarning
                        });
                    });
                }
              
              }); 

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<DataManagementContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                options.Lockout.DefaultLockoutTimeSpan = System.TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = true;

                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;


            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = System.TimeSpan.FromMinutes(15);

                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/";
                options.SlidingExpiration = true;

            });

            //Repositories
            services.AddScoped<IFactoryRepository, FactoryRepository>();
            services.AddScoped<IFactoryCollectionsRepository, FactoryCollectionRepository>();
            services.AddScoped<IWorkerRepository, WorkerRepository>();
            services.AddScoped<IWorkerTrackerRepository, WorkerTrackerRepository>();
            services.AddScoped<IAccountsRepository, AccountsRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();

            //services
            services.AddScoped<IFactoryService, FactoryService>();
            services.AddScoped<IWorkerService, WorkerService>();
            services.AddScoped<IAccountsService, AccountsService>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseCors();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
        }
    }
}
