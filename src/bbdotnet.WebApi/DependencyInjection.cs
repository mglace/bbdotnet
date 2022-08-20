namespace bbdotnet.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiLayer(this IServiceCollection services) 
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);

            return services;
        }
    }
}
