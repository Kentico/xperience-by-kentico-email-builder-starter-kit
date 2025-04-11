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
    [ContentItemSelectorComponent(typeof(ProductContentTypesFilter), Label = "Select a web page.", MaximumItems = 1,
        Order = 1)]
    public IEnumerable<ContentItemReference> Pages { get; set; } = [];

    /// <summary>
    /// Web page item url position.
    /// </summary>
    [DropDownComponent(
        Label = "Web Page Link Button Position",
        Order = 2,
        ExplanationText = "Select where to display the link to the original web page item.",
        Options = $"{nameof(WebPageItemUrlPositionType.Above)};{nameof(WebPageItemUrlPositionType.Above)}" +
        $"\r\n{nameof(WebPageItemUrlPositionType.Below)};{nameof(WebPageItemUrlPositionType.Below)}" +
        $"\r\n{nameof(WebPageItemUrlPositionType.Title)};{nameof(WebPageItemUrlPositionType.Title)}" +
        $"\r\n{nameof(WebPageItemUrlPositionType.NotDisplayed)};{nameof(WebPageItemUrlPositionType.NotDisplayed)}",
        OptionsValueSeparator = ";")]
    public string WebPageItemUrlPosition { get; set; } = nameof(WebPageItemUrlPositionType.Below);

    /// <summary>
    /// Text of the button which links the original web page item.
    /// </summary>
    [TextInputComponent(
        Label = "Go to Web Page Button Text",
        Order = 3,
        ExplanationText = "Set the text of the button which links the original web page item.")]
    public string ReadMoreButtonText { get; set; } = "READ MORE";
}
