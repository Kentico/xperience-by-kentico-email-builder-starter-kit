using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public class ProductWidgetProperties : IEmailWidgetProperties
{
    [DropDownComponent(Label = "Content item", DataProviderType = typeof(ProductEmailWidgetContentTypeOptionsProvider))]
    public string ContentItemGuid { get; set; } = string.Empty;
}
