using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
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
using NHibernate;
using System.Linq;
using vidaminRestService.Data;
using vidaminRestService.DBContexts;
using vidaminRestService.Mapping;
using vidaminRestService.Service;

namespace vidaminRestService
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

            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "vidaminRestService", Version = "v1" });
            });

            services.AddMvc();

            string mySqlConnectionStr = AESService.Decrypt(Configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<MyDBContext>(c =>
                c.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));



          

            services.AddSingleton<NHibernate.ISessionFactory>(
                   factory =>
                   {
                       return Fluently.Configure().Database(
                                                            MySQLConfiguration.Standard.ConnectionString(mySqlConnectionStr)
                                                            )
                                                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ForumUserMapping>())


                      .BuildConfiguration()
                      .BuildSessionFactory();
                   }
               );

            services.AddSingleton<NHibernate.ISession>(factory => factory.GetServices<ISessionFactory>().First().OpenSession());
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "vidaminRestService v1"));
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
