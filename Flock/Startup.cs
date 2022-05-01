using Flock.IServices;
using Flock.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Flock
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                //Obtenemos el directorio actual
                var basePath = AppContext.BaseDirectory;
                //Obtenemos el nombre de la dll por medio de reflexión
                var assemblyName = System.Reflection.Assembly
                              .GetEntryAssembly().GetName().Name;
                //Al nombre del assembly le agregamos la extensión xml
                var fileName = System.IO.Path
                              .GetFileName(assemblyName + ".xml");
                //Agregamos el Path, es importante utilizar el comando
                var xmlPath = Path.Combine(basePath, fileName);
                c.IncludeXmlComments(xmlPath);

            });

        


            services.AddDbContext<flockContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUsuario, DataAccess.Usuario>();
            services.AddScoped<IProvincia, Service.Provincia>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Flock");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
