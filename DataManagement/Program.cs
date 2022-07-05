using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;

namespace DataManagement
{
    class Program
    {
        public static void Main(string[]args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
        }
    }
}