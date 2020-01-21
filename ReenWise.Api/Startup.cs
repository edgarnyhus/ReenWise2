using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReenWise.Infrastructure.Data.Context;
using ReenWise.Infrastructure.IoC;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using AutoMapper;
using Newtonsoft.Json.Serialization;


namespace ReenWise.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false);

            //Configuration = builder.Build();
            //var myvalue = Configuration["ClientCredentials:ClientId"];
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {   
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    //System.Text.Json.
                });
            //var test = services.Configure<AccessToken.ClientCredentials>(Configuration.GetSection("ClientCredentials"));

            //AccessToken.GetToken();

            // ==> Added configured services
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ReenWiseDbContext>(options =>
            {
                options.UseSqlServer(
                    Configuration.GetConnectionString("ReenWiseDbConnection"),
                    x => x.UseNetTopologySuite());
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null); ;

            //services.AddMvc().AddJsonOptions(opt =>
            //{
            //    opt.SerializerSettings.ContractResolver = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() };
            //    opt.JsonSerializerOptions.PropertyNamingPolicy = new DefaultContractResolver { NamingStrategy = new SnakeCaseNamingStrategy() };
            //});
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ReenWise Api", Version = "v1" });
            });

            services.AddMediatR(typeof(Startup));
            RegisterServices(services);
            // <==
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // ==> Added configuration
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ReenWise Api v1"));
            // <==

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void RegisterServices(IServiceCollection services)
        {
            DependencyContainer.RegisterServices(services);
        }

    }
}
