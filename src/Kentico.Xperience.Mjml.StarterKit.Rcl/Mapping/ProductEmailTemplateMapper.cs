using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

public interface IProductEmailTemplateMapper : IEmailTemplateMapper<ProductWidgetModel>
{ }

public abstract class ProductEmailTemplateMapper : IProductEmailTemplateMapper
{
    public virtual string WebPageItemSelectorDisplayedMessage { get; set; } = string.Empty;
    public virtual Task<ProductWidgetModel> MapProperties(Guid webPageItemGuid) => Task.FromResult(new ProductWidgetModel());
}
