using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ButtonWidget"/>.
/// </summary>
public class ButtonWidgetProperties : IEmailWidgetProperties
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
        ExplanationText = "Enter the button link URL")]
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// The button html element type. <see cref="ButtonType"/>
    /// </summary>
    [DropDownComponent(
        Label = "Button Type",
        Order = 3,
        ExplanationText = "Select the button type",
        Options = $"{nameof(Widgets.ButtonType.Button)};{nameof(Widgets.ButtonType.Button)}\r\n{nameof(Widgets.ButtonType.Link)};{nameof(Widgets.ButtonType.Link)}",
        OptionsValueSeparator = ";")]
    public string ButtonType { get; set; } = nameof(Widgets.ButtonType.Button);

    /// <summary>
    /// The horizontal alignment of the button. <see cref="ButtonHorizontalAlignment"/>
    /// </summary>
    [DropDownComponent(
        Label = "Alignment",
        Order = 11,
        ExplanationText = "Select button alignment",
        Options = $"{nameof(ButtonAlignment.Left)};{nameof(ButtonAlignment.Left)}\r\n{nameof(ButtonAlignment.Centre)};{nameof(ButtonAlignment.Centre)}\r\n{nameof(ButtonAlignment.Right)};{nameof(ButtonAlignment.Right)}",
        OptionsValueSeparator = ";")]
    public string ButtonHorizontalAlignment { get; set; } = nameof(ButtonAlignment.Left);
}

/// <summary>
/// The type of html element rendered by button widget.
/// </summary>
public enum ButtonType
{
    /// <summary>
    /// <button/> html element.
    /// </summary>
    Button,

    /// <summary>
    /// <a/> html element.
    /// </summary>
    Link
}

/// <summary>
/// The button horizontal alignment.
/// </summary>
public enum ButtonAlignment
{
    /// <summary>
    /// Left
    /// </summary>
    Left,

    /// <summary>
    /// Centre.
    /// </summary>
    Centre,

    /// <summary>
    /// Right.
    /// </summary>
    Right
}
