using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

/// <summary>
/// Mapper of <see cref="ProductWidgetModel"/> for <see cref="ProductWidget"/>
/// </summary>
public interface IProductEmailTemplateMapper : IEmailTemplateMapper<ProductWidgetModel>
{ }

/// <inheritdoc />
public abstract class ProductEmailTemplateMapper : IProductEmailTemplateMapper
{
    /// <summary>
    /// Based on a web page item guid maps a web page item to <see cref="ProductWidgetModel"/> model.
    /// </summary>
    /// <param name="webPageItemGuid">The guid of a web page item.</param>
    /// <returns>The <see cref="ProductWidgetModel"/>.</returns>
    public virtual Task<ProductWidgetModel> MapProperties(Guid webPageItemGuid) => Task.FromResult(new ProductWidgetModel());
}
