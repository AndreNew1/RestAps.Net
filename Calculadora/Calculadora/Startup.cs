using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Calculadora.Model.Context;
using Calculadora.Business;
using Calculadora.Business.Implementattions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Calculadora.Repository;
using Calculadora.Repository.Implementattions;

namespace Calculadora
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }
        public Startup(IConfiguration configuration,IHostingEnvironment environment,ILogger<Startup> logger)
        {
            _Configuration = configuration;
            _logger = logger;
            _environment = environment;
        }

        public IConfiguration _Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseSqlServer(connectionString));
           // if (_environment.IsDevelopment())
           // {
           //     try
           //     {
           //        var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
           //         var evolve = new Evolve.Evolve(evolveConnection, msg => _logger.LogInformation(msg))
           //        {
           //             Locations = new List<string> { "Db/migrations" },
           //             IsEraseDisabled = true,
           //
           //         };
           //         evolve.Migrate();
           //     }
           //     catch (Exception e)
           //     {
           //         _logger.LogCritical("Database migration failed.", e);
           //        throw;
           //     }
           // }


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddApiVersioning();

            //Injeção de dependencia
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
