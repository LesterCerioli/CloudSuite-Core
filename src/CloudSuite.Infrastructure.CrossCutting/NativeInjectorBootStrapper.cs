using CloudSuite.Domain.Contracts;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace CloudSuite.Infrastructure.CrossCutting
{
	public class NativeInjectorBootStrapper
	{
		public static void RegisterServices(IServiceCollection services)
		{
            services.AddScoped<CoreDbContext>();
            services.AddScoped<IAddressRepository>();
            services.AddScoped<ICityRepository>();
            services.AddScoped<ICompanyRepository>();
            services.AddScoped<ICountryRepository>();
            services.AddScoped<IDistrictRepository>();
            services.AddScoped<IEmailRepository>();
            services.AddScoped<IMediaRepository>();
            services.AddScoped<IStateRepository>();
            services.AddScoped<IUserRepository>();
            services.AddScoped<IVendorRepository>();

            // Application
            services.AddScoped<ICityAppService, CityAppService>();
            services.AddScoped<IAddressAppService, AddressAppService>();
            services.AddScoped<ICompanyAppService, CompanyAppService>();
            services.AddScoped<ICountryAppService, CountryAppService>();
            services.AddScoped<IDistrictAppService, DistrictAppService>();
            services.AddScoped<IEmailAppService, EmailAppService>();
            services.AddScoped<IMediaAppService, MediaAppService>();
            services.AddScoped<IStateAppService, StateAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IVendorAppService, VendorAppService>();


        }
	}
}