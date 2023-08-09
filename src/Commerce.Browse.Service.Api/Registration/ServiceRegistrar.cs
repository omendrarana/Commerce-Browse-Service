using commercetools.Base.Client;
using System.Reflection;
using Commerce.Browse.Service.ContentStack.Provider.Interfaces;
using Commerce.Browse.Service.CommerceTools.Provider.Interface;
using Commerce.Browse.Service.Domain.Handlers;
using Commerce.Browse.Service.ContentStack.Provider.Providers;
using Commerce.Browse.Service.CommerceTools.Provider.Providers;

namespace Commerce.Browse.Service.WebApi.Registration
{
    public static class ServiceRegistrar
    {
        internal static void AddMediatRClasses(IServiceCollection services, IConfiguration configurationdata)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
                typeof(GetProductHandler).Assembly,
                typeof(CreateProductHandler).Assembly,
                typeof(UpdateProductCommand).Assembly,
                typeof(DeleteProductHandler).Assembly
            ));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddAutoMapper(typeof(Program).Assembly);

            services.AddSingleton<IProductCommerceToolsProvider>(x => new ProductCommerceToolsProvider(x.GetRequiredService<IClient>()));
            services.AddSingleton<IProductContentStackProvider>(x => new ContentStackProvider());
        }

        internal static IConfigurationRoot GetConfiguration(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>(true)
                .Build();

            return configuration;
        }

    }
}
