using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
           .UseKestrel()
           .UseContentRoot(Directory.GetCurrentDirectory())
           .UseUrls("https://localhost:3001", "http://127.0.0.1:3000", "https://:::3000")
           .UseIISIntegration()
           .UseStartup<Startup>()
           .UseWebRoot(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") )
            .Build();

           host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
