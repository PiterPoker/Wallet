using Microsoft.EntityFrameworkCore;
using Wallet.API.Applications.Exceptions;
using Wallet.API.Applications;
using Wallet.API.Services;
using Wallet.API.Services.Abstractions;
using Wallet.Domain.SeedWork;
using Wallet.Infrastructure;
using Wallet.Infrastructure.Repositories;
using WalletOfFamily = Wallet.Domain.Models.WalletOfFamily;
using Wallet.Domain.Repositories;
using Wallet.Domain.Models.AccountOfPerson;

namespace Wallet.API
{
    public static class CustomServicesExtensions
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            // Pooling is disabled because of the following error:
            // Unhandled exception. System.InvalidOperationException:
            if (Environment.GetEnvironmentVariable("CONNECTION_STRING") is string dockerConnectionString)
            {
                // The DbContext of type 'OrderingContext' cannot be pooled because it does not have a public constructor accepting a single parameter of type DbContextOptions or has more than one constructor.
                services.AddDbContext<WalletDBContext>(options =>
                {
                    options.UseLazyLoadingProxies();
                    options.UseNpgsql(dockerConnectionString);
                });
            }
            else if (configuration.GetConnectionString("DefaultConnection") is string appSettingsConnectionString)
            {
                services.AddDbContext<WalletDBContext>(options =>
                {
                    options.UseLazyLoadingProxies();
                    options.UseNpgsql(appSettingsConnectionString);
                });
            }
            else
            {
                // The DbContext of type 'OrderingContext' cannot be pooled because it does not have a public constructor accepting a single parameter of type DbContextOptions or has more than one constructor.

                throw new WalletAPIException("Connection string cannot be found");
            }

            return services;
        }

        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
            });

            return services;
        }

        public static IServiceCollection AddCustomMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Program));

            return services;
        }

        public static IServiceCollection AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<WalletOfFamily.Wallet, long>, WalletRepository<WalletOfFamily.Wallet, long>>();
            services.AddScoped<IRepository<WalletOfFamily.Family, long>, FamilyRepository<WalletOfFamily.Family, long>>();
            services.AddScoped<ISubWalletRepository<WalletOfFamily.SubWallet, long>, SubWalletRepository<WalletOfFamily.SubWallet, long>>();
            services.AddScoped<IAccountRepository<Account, long>, AccountRepository<Account, long>>();
            return services;
        }

        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<ISubWalletService, SubWalletService>();
            services.AddScoped<IAccountService, AccountService>();
            return services;
        }

        public static IServiceCollection AddCustomJsonSerializer(this IServiceCollection services)
        {
            // ��������� ������������ JSON ��� �������������� ����������� ������
            services.AddControllers()
                .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
                    //options.JsonSerializerOptions.MaxDepth = 64; // ����� ������������ �������, ���� ���������
                });
            return services;
        }
    }
}
