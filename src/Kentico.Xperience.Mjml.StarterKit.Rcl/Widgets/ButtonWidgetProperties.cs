using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets.Enums;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ButtonWidget"/>.
/// </summary>
public sealed class ButtonWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// The button text.
    /// </summary>
    [TextInputComponent(
        Label = "Button Text",
        Order = 1,
        ExplanationText = "Enter the button text")]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// The url linked by button.
    /// </summary>
    [TextInputComponent(
        Label = "URL",
        Order = 2,
        ExplanationText = "Enter the button link URL. Allowed formats: absolute (starting with protocol), rooted (starting with /), or virtual (starting with ~)")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// The button html element type. <see cref="ButtonType"/>
    /// </summary>
    [DropDownComponent(
        Label = "Button Type",
        Order = 3,
        ExplanationText = "Select the button type",
        Options = $"{nameof(Enums.ButtonType.Button)};{nameof(Enums.ButtonType.Button)}\r\n{nameof(Enums.ButtonType.Link)};{nameof(Enums.ButtonType.Link)}",
        OptionsValueSeparator = ";")]
    public string ButtonType { get; set; } = nameof(Enums.ButtonType.Button);

    /// <summary>
    /// The horizontal alignment of the button. <see cref="ButtonHorizontalAlignment"/>
    /// </summary>
    [DropDownComponent(
        Label = "Alignment",
        Order = 11,
        ExplanationText = "Select button alignment",
        Options = $"{nameof(ButtonHorizontalAlingnmentType.Left)};{nameof(ButtonHorizontalAlingnmentType.Left)}\r\n{nameof(ButtonHorizontalAlingnmentType.Centre)};{nameof(ButtonHorizontalAlingnmentType.Centre)}\r\n{nameof(ButtonHorizontalAlingnmentType.Right)};{nameof(ButtonHorizontalAlingnmentType.Right)}",
        OptionsValueSeparator = ";")]
    public string ButtonHorizontalAlignment { get; set; } = nameof(ButtonHorizontalAlingnmentType.Left);
}
