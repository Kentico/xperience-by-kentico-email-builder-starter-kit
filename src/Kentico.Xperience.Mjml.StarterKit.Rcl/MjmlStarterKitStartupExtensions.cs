using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// Application startup extension methods.
/// </summary>
public static class MjmlStarterKitStartupExtensions
{
    /// <summary>
    /// Adds mjml starter kit services to application with customized options.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> which will be modified.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> where <see cref="MjmlStarterKitOptions"/> are specified.</param>
    /// <returns>This instance of <see cref="IServiceCollection"/>, allowing for further configuration in a fluent manner.</returns>
    public static IServiceCollection AddKenticoMjmlStarterKit(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<CssLoaderService>()
        .AddScoped<IUrlHelper>(provider =>
        {
            var actionContext = provider.GetRequiredService<IActionContextAccessor>().ActionContext!;
            return new UrlHelper(actionContext);
        })
        .Configure<MjmlStarterKitOptions>(configuration.GetSection(nameof(MjmlStarterKitOptions)));

        return services;
    }
}
