using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public class ButtonWidgetProperties : IEmailWidgetProperties
{
    [TextInputComponent(
        Label = "Button Text",
        Order = 1,
        ExplanationText = "Enter the button text")]
    public string Text { get; set; } = string.Empty;

    [TextInputComponent(
        Label = "URL",
        Order = 2,
        ExplanationText = "Enter the button link URL")]
    public string Url { get; set; } = string.Empty;

    [DropDownComponent(
        Label = "Button Type",
        Order = 3,
        ExplanationText = "Select the button type",
        Options = $"{nameof(Widgets.ButtonType.Button)};{nameof(Widgets.ButtonType.Button)}\r\n{nameof(Widgets.ButtonType.Link)};{nameof(Widgets.ButtonType.Link)}",
        OptionsValueSeparator = ";")]
    public string ButtonType { get; set; } = nameof(Widgets.ButtonType.Button);

    [DropDownComponent(
        Label = "Alignment",
        Order = 11,
        ExplanationText = "Select button alignment",
        Options = $"{nameof(ButtonAlignment.Left)};{nameof(ButtonAlignment.Left)}\r\n{nameof(ButtonAlignment.Center)};{nameof(ButtonAlignment.Center)}\r\n{nameof(ButtonAlignment.Right)};{nameof(ButtonAlignment.Right)}",
        OptionsValueSeparator = ";")]
    public string ButtonHorizontalAligment { get; set; } = nameof(ButtonAlignment.Left);
}

public enum ButtonType
{
    Button,
    Link
}

public enum ButtonAlignment
{
    Left,
    Center,
    Right
}
