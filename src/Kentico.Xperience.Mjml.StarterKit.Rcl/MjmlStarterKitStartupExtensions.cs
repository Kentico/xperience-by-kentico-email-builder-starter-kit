using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

public static class MjmlStarterKitStartupExtensions
{
    public static IServiceCollection AddKenticoMjmlStarterKit(this IServiceCollection services, IConfiguration configuration)
    => services.AddScoped<CssLoaderService>()
        .AddScoped<IUrlHelper>(provider =>
        {
            var actionContext = provider.GetRequiredService<IActionContextAccessor>().ActionContext!;
            return new UrlHelper(actionContext);
        })
        .Configure<MjmlStarterKitOptions>(configuration.GetSection(nameof(MjmlStarterKitOptions)));
}
