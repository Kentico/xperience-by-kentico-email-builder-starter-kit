using CMS.ContentEngine;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets.Enums;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ImageWidget"/>.
/// </summary>
public sealed class ImageWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// The image.
    /// </summary>
    [ContentItemSelectorComponent(typeof(ImageContentTypesFilter), Order = 1, Label = "Image", ExplanationText = "Image from the content hub.")]
    public IEnumerable<ContentItemReference> Assets { get; set; } = [];
    
    /// <summary>
    /// The horizontal alignment of the button. <see cref="HorizontalAlignment"/>
    /// </summary>
    [DropDownComponent(
        Label = "Alignment",
        Order = 2,
        ExplanationText = "Select image alignment",
        Options = $"{nameof(HorizontalAlignment.Left)};{nameof(HorizontalAlignment.Left)}\r\n{nameof(HorizontalAlignment.Center)};{nameof(HorizontalAlignment.Center)}\r\n{nameof(HorizontalAlignment.Right)};{nameof(HorizontalAlignment.Right)}",
        OptionsValueSeparator = ";")]
    public string Alignment { get; set; } = nameof(HorizontalAlignment.Left);

    /// <summary>
    /// The image width.
    /// </summary>
    [NumberInputComponent(Label = "Width", Order = 3)]
    public int Width { get; set; } = 200;
}
