using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;
using TrainingAgin.DatabaseModel;

namespace TrainingAgin
{
    class Program
    {
        static void Main(string[] args) => CreateHostBuilder(args).Build().Run();
        public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            
            .ConfigureServices((hostContext, services)=>
            {
                services.AddDbContext<OrderContext>(options => options.UseSqlServer
                (hostContext.Configuration.GetConnectionString("DefaultConnection")));
                services.AddHostedService<mainService>();
            })
            .UseSerilog(new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("C:\\trian1\\trian.txt")
            .CreateLogger()
            );

    }
}
