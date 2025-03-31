using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

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
    /// Adds mjml starter kit services to application with customized options provided by the <see cref="IMjmlStarterKitBuilder"/>.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> which will be modified.</param>
    /// <param name="configuration">The <see cref="IConfiguration"/> where <see cref="MjmlStarterKitOptions"/> are specified.</param>
    /// <param name="configure"><see cref="Action"/> which will configure the <see cref="IMjmlStarterKitBuilder"/>.</param>
    /// <returns>This instance of <see cref="IServiceCollection"/>, allowing for further configuration in a fluent manner.</returns>
    public static IServiceCollection AddKenticoMjmlStarterKit(this IServiceCollection services, IConfiguration configuration, Action<IMjmlStarterKitBuilder> configure)
    {
        services.AddScoped<CssLoaderService>()
        .AddScoped<IMediaFileService, MediaFileService>()
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

/// <summary>
/// The mjml starter kit builder used to configure the <see cref="WidgetDataRetriever{TWidgetModel}"/>s.
/// </summary>
public interface IMjmlStarterKitBuilder
{
    /// <summary>
    /// Registers the given <typeparamref name="TWidgetDataRetriever"/> for given <typeparamref name="TWidgetModel"/> as a scoped service.
    /// </summary>
    /// <returns>Returns this instance of <see cref="IMjmlStarterKitBuilder"/>, allowing for further configuration in a fluent manner.</returns>
    IMjmlStarterKitBuilder RegisterWidgetDataRetriever<TWidgetDataRetriever, TWidgetModel>() where TWidgetDataRetriever : class, WidgetDataRetriever<TWidgetModel>;
}


internal class MjmlStarterKitBuilder : IMjmlStarterKitBuilder
{
    private readonly IServiceCollection serviceCollection;
    public MjmlStarterKitBuilder(IServiceCollection serviceCollection)
    => this.serviceCollection = serviceCollection;

    public IMjmlStarterKitBuilder RegisterWidgetDataRetriever<TMapper, TWidgetModel>() where TMapper : class, WidgetDataRetriever<TWidgetModel>
    {
        serviceCollection.AddScoped<WidgetDataRetriever<TWidgetModel>, TMapper>();

        return this;
    }
}
