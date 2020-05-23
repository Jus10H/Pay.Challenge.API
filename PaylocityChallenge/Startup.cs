using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PaylocityChallenge.BLL;
using PaylocityChallenge.DLL;

namespace PaylocityChallenge
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
            services.AddCors();

            services.AddControllers();

            var mappingConfig = new MapperConfiguration(mapconfig =>
            {
                mapconfig.AddProfile(new MapProfile());
            });
            services.AddSingleton(mappingConfig.CreateMapper());

            services.AddDbContext<PaylocityDbContext>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IEmployeeService, EmployeeService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseCors(builder => builder.WithOrigins(Configuration.GetValue<string>("AllowedCorsOrigin"))
            .AllowAnyMethod()
            .WithHeaders("accept", "content-type", "origin"));

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
