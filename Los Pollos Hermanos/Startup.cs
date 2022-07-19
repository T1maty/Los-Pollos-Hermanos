using Los_Pollos_Hermanos.Helpers.Seed;
using AutoMapper;
using Los_Pollos_Hermanos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Los_Pollos_Hermanos.Services;
using Los_Pollos_Hermanos.Services.Interfaces;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2;
using Amazon.Runtime;

namespace Los_Pollos_Hermanos
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            MapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new MappingProfiles()); });
        }
        private MapperConfiguration MapperConfiguration { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddDbContext<LosPollosHermanosContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("LPHermanosSqlDb")));

            services.AddSingleton(c => MapperConfiguration.CreateMapper());

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowCredentials()
                    .AllowAnyHeader());

            });
            services.AddMvc();
            services.AddScoped<IUserService, UserService>();

            var credendtials = new BasicAWSCredentials("", "");
            var config = new AmazonDynamoDBConfig()
            {
                RegionEndpoint = Amazon.RegionEndpoint.APSoutheast2
            };

            var client = new AmazonDynamoDBClient(credentials, config);
            services.AddSingleton<IAmazonDynamoDB>(client);
            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();


            services.AddIdentity<User, AppRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<LosPollosHermanosContext>()

                .AddDefaultTokenProviders();

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" }); });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<User> userManager)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseMiddleware<ErrorHandlerMiddleware>();

            
            app.UseSwagger();
            

            
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1"); });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
          
        }
    }
}

    

