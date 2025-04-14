using CMS.ContentEngine;
using CMS.Websites;

using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets.Enums;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ProductWidget"/>.
/// </summary>
public sealed class ProductWidgetProperties : WidgetPropertiesBase
{
    /// <summary>
    /// Specifies the <see cref="WebPageRelatedItem"/> which is used as the content of the product widget.
    /// </summary>
    [ContentItemSelectorComponent(typeof(ProductContentTypesFilter), 
        Label = "{$ProductWidget.Page.Label$}", 
        MaximumItems = 1,
        Order = 1,
        ExplanationText = "{$ProductWidget.Page.ExplanationText$}")]
    public IEnumerable<ContentItemReference> Pages { get; set; } = [];

    /// <summary>
    /// Text of the button which links the original web page item.
    /// </summary>
    [TextInputComponent(
        Label = "{$ProductWidget.ReadMoreButton.Label$}",
        Order = 3,
        ExplanationText = "{$ProductWidget.ReadMoreButton.ExplanationText$}")]
    public string ReadMoreButtonText { get; set; } = "READ MORE";
}
