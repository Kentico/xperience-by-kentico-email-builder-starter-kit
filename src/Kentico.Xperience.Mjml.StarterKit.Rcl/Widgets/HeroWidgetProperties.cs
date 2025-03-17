using CMS.MediaLibrary;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="HeroWidget"/>.
/// </summary>
public sealed class HeroWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// The image.
    /// </summary>
    [AssetSelectorComponent(Label = "Image", Order = 1, ExplanationText = "Image from a library.", AllowedExtensions = "jpg;jpeg;png", MaximumAssets = 1)]
    public IEnumerable<AssetRelatedItem> Image { get; set; } = [];

    /// <summary>
    /// The alt text of the image.
    /// </summary>
    [TextInputComponent(
        Label = "Alt Text",
        Order = 2,
        ExplanationText = "Enter alternative text for the image")]
    public string AltText { get; set; } = string.Empty;

    /// <summary>
    /// Text description of the image.
    /// </summary>
    [TextAreaComponent(
        Label = "Description",
        Order = 3,
        ExplanationText = "Enter description text")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Vertical positioning of the description relative to the image.
    /// </summary>
    [DropDownComponent(
        Label = "Description Position",
        Order = 4,
        ExplanationText = "Select where to display the description",
        Options = $"{nameof(Widgets.DescriptionPosition.Below)};{nameof(Widgets.DescriptionPosition.Below)}\r\n{nameof(Widgets.DescriptionPosition.Above)};{nameof(Widgets.DescriptionPosition.Above)}",
        OptionsValueSeparator = ";")]
    public string DescriptionPosition { get; set; } = nameof(Widgets.DescriptionPosition.Below);
}

/// <summary>
/// Vertical position of the description relative to the image.
/// </summary>
public enum DescriptionPosition
{
    /// <summary>
    /// Above the image.
    /// </summary>
    Above,

    /// <summary>
    /// Below the image
    /// </summary>
    Below
}
