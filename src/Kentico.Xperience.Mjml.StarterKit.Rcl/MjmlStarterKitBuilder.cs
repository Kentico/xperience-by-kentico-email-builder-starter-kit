using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

internal class MjmlStarterKitBuilder(IServiceCollection serviceCollection) : IMjmlStarterKitBuilder
{
    public IMjmlStarterKitBuilder RegisterWidgetDataRetriever<TWidgetDataRetriever, TWidgetModel>() where TWidgetDataRetriever : class, IComponentModelMapper<TWidgetModel>
    {
        serviceCollection.AddScoped<IComponentModelMapper<TWidgetModel>, TWidgetDataRetriever>();

        return this;
    }
}
