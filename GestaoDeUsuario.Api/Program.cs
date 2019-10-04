using System;
using System.Net;
using GestaoDeUsuario.Infra;
using GestaoDeUsuario.Infra.Contexto;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GestaoDeUsuario.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            #region Seed - Dados iniciais

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<EfDbContext>();
            //        Seed.Initialize(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "Ocorreu um erro durante a propagação do banco de dados.");
            //    }
            //}

            #endregion 

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseKestrel(options =>
            {
                options.Listen(IPAddress.Loopback, 5000);
                options.Listen(IPAddress.Loopback, 5001, listenOptions =>
                {
                    //listenOptions.UseHttps("certificado_api_core.pfx", "1q2w3e4r");
                });
            })
                .UseStartup<Startup>();
    }
}
