using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

public static class MjmlStarterKitStartupExtensions
{
    public static IServiceCollection AddMjmlStarterKit(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IUrlHelper>(provider =>
        {
            var actionContext = provider.GetRequiredService<IActionContextAccessor>().ActionContext!;
            return new UrlHelper(actionContext);
        });
        return serviceCollection;
    }
}
