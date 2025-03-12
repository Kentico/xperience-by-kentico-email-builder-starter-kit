using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

public static class MjmlStarterKitStartupExtensions
{
    public static IServiceCollection AddKenticoMjmlStarterKit(this IServiceCollection services, IConfiguration configuration, Action<IMjmlStarterKitBuilder> configure)
    {
        services.AddScoped<CssLoaderService>()
        .AddScoped<IUrlHelper>(provider =>
        {
            var actionContext = provider.GetRequiredService<IActionContextAccessor>().ActionContext!;
            return new UrlHelper(actionContext);
        })
        .Configure<MjmlStarterKitOptions>(configuration.GetSection(nameof(MjmlStarterKitOptions)));

        var builder = new MjmlStarterKitBuilder(services);

        configure(builder);

        return services;
    }
}

public interface IMjmlStarterKitBuilder
{
    IMjmlStarterKitBuilder RegisterProductMapper<TMapper>() where TMapper : class, IProductEmailTemplateMapper;
    IMjmlStarterKitBuilder RegisterArticleMapper<TMapper>() where TMapper : class, IArticleEmailTemplateMapper;
}

internal class MjmlStarterKitBuilder : IMjmlStarterKitBuilder
{
    private readonly IServiceCollection serviceCollection;
    public MjmlStarterKitBuilder(IServiceCollection serviceCollection)
    => this.serviceCollection = serviceCollection;

    public IMjmlStarterKitBuilder RegisterProductMapper<TMapper>() where TMapper : class, IProductEmailTemplateMapper
    {
        serviceCollection.AddScoped<IProductEmailTemplateMapper, TMapper>();

        return this;
    }

    public IMjmlStarterKitBuilder RegisterArticleMapper<TMapper>() where TMapper : class, IArticleEmailTemplateMapper
    {
        serviceCollection.AddScoped<IArticleEmailTemplateMapper, TMapper>();

        return this;
    }
}
