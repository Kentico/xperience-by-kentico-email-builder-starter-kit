using CMS.Websites;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ArticleWidget"/>.
/// </summary>
public class ArticleWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// Configures the vertical position where the content is displayed relative to the image..
    /// </summary>
    [DropDownComponent(
        Label = "Content Position",
        Order = 4,
        ExplanationText = "Select where to display the content relative to the displayed image.",
        Options = $"{nameof(ContentPositionOption.Above)};{nameof(ContentPositionOption.Above)}\r\n{nameof(ContentPositionOption.Below)};{nameof(ContentPositionOption.Below)}",
        OptionsValueSeparator = ";")]
    public string ContentPosition { get; set; } = nameof(ContentPositionOption.Above);

    /// <summary>
    /// Specifies the <see cref="WebPageRelatedItem"/> which is used as the content of the article widget.
    /// </summary>
    [WebPageSelectorComponent(Label = "Select a web page.", MaximumPages = 1)]
    public IEnumerable<WebPageRelatedItem> Pages { get; set; } = [];
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
