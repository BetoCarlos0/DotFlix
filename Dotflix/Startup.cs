using ApiDotflix.Data;
using ApiDotflix.Data.Repository;
using ApiDotflix.Data.Services;
using ApiDotflix.Entities.Models.Contracts.Repositories;
using ApiDotflix.Entities.Models.Contracts.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;

namespace ApiDotflix
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

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IMovieService, MovieService>();

            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAboutService, AboutService>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            //services.AddDbContext<DotflixDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("SqlServer"),
            //        x => x.MigrationsAssembly(typeof(DotflixDbContext).Assembly.FullName)));

            services.AddDbContext<DotflixDbContext>(options =>
                options.UseInMemoryDatabase("ImMemory"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Api Dotflix",
                    Version = "v1",
                    Description = "Api simples de CRUD da Netflix",
                    Contact = new OpenApiContact
                    {
                        Name = "Roberto Carlos",
                        Email = "betocarlos00@hotmail.com",
                        Url = new Uri("https://github.com/BetoCarlos0"),
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dotflix v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
