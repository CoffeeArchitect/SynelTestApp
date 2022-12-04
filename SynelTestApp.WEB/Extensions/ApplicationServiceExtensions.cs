

using SynelTestApp.BLL.Helpers;

namespace SynelTestApp.WEB.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            var connStr = config.GetConnectionString("DefaultConnection");

            services.AddScoped<IRepository, Repository>();
            services.AddTransient<IParsingService, ParsingService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<EmployeeDbContext>(options =>
            {
                options.UseSqlServer(connStr);
            });

            services.AddMvc().AddNewtonsoftJson(options =>
            options.SerializerSettings.ContractResolver =
               new DefaultContractResolver());

            return services;
        }
    }
}
