using CMS.Websites;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ArticleWidget"/>.
/// </summary>
public sealed class ArticleWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// Specifies the <see cref="WebPageRelatedItem"/> which is used as the content of the article widget.
    /// </summary>
    [WebPageSelectorComponent(Label = "Select a web page.",
        MaximumPages = 1,
        Order = 1)]
    public IEnumerable<WebPageRelatedItem> Pages { get; set; } = [];


    /// <summary>
    /// Configures the vertical position where the content is displayed relative to the image..
    /// </summary>
    [DropDownComponent(
        Label = "Content Position",
        Order = 2,
        ExplanationText = "Select where to display the content relative to the displayed image.",
        Options = $"{nameof(ContentPositionOption.Above)};{nameof(ContentPositionOption.Above)}\r\n{nameof(ContentPositionOption.Below)};{nameof(ContentPositionOption.Below)}",
        OptionsValueSeparator = ";")]
    public string ContentPosition { get; set; } = nameof(ContentPositionOption.Above);

    /// <summary>
    /// Web page item url position.
    /// </summary>
    [DropDownComponent(
        Label = "Web Page Link Button Position",
        Order = 3,
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
        Order = 4,
        ExplanationText = "Set the text of the button which links the original web page item.")]
    public string ReadMoreButtonText { get; set; } = "READ MORE";
}

/// <summary>
/// Vertical positioning of the text content within a widget relative to the displayed image.
/// </summary>
public enum ContentPositionOption
{
    /// <summary>
    /// Display content above an image.
    /// </summary>
    Above,
    /// <summary>
    /// Display content below image.
    /// </summary>
    Below
}
