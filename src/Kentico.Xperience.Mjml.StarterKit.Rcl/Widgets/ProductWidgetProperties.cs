using CMS.Websites;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ProductWidget"/>.
/// </summary>
public sealed class ProductWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// Specifies the <see cref="WebPageRelatedItem"/> which is used as the content of the product widget.
    /// </summary>
    [WebPageSelectorComponent(Label = "Select a web page.", MaximumPages = 1)]
    public IEnumerable<WebPageRelatedItem> Pages { get; set; } = [];
}
