using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Turismo.Template.AccessData.Command;
using Turismo.Template.AccessData.Context;
using Turismo.Template.Application.Services;
using Turismo.Template.Domain.Commands;


namespace Turismo.Template.API
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
            //var connectionString = Configuration.GetSection("ConnectionString").Value; //busca las configuraciones del sistema
            services.AddDbContext<DbContextGeneric>(options => options.UseSqlServer(@"server=localhost;database=MsUser;trusted_connection=True;"));
            services.AddTransient<IRepositoryGeneric, GenericsRepository>();
            services.AddTransient<IUserService, UserService>();
            //Se agrega en generador de Swagger
            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {

                var groupName = "test";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Prototype {groupName}",
                    Version = groupName,
                    Description = "Prototype API",
                    Contact = new OpenApiContact
                    {
                        Name = "Projecto Software",
                        Email = string.Empty,
                        Url = new Uri("https://algo.com/"),
                    }
                });

            });
            services.AddSwaggerGen(c =>
            {
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            //indica la ruta para generar la configuración de swagger
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/test/swagger.json", "Prototype API V1");
            });
        }

    }
}