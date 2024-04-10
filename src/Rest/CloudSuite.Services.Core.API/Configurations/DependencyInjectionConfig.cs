using CloudSuite.Infrastructure.CrossCutting;

namespace CloudSuite.Services.Core.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			NativeInjectorBootStrapper.RegisterServices(services);
		}

        
    }
}