using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// The mjml starter kit builder used to configure the <see cref="IComponentModelMapper{TWidgetModel}"/>s.
/// </summary>
public interface IMjmlStarterKitBuilder
{
    /// <summary>
    /// Registers the given <typeparamref name="TWidgetDataRetriever"/> for given <typeparamref name="TWidgetModel"/> as a scoped service.
    /// </summary>
    /// <returns>Returns this instance of <see cref="IMjmlStarterKitBuilder"/>, allowing for further configuration in a fluent manner.</returns>
    public IMjmlStarterKitBuilder RegisterWidgetDataRetriever<TWidgetDataRetriever, TWidgetModel>() where TWidgetDataRetriever : class, IComponentModelMapper<TWidgetModel>;
}
