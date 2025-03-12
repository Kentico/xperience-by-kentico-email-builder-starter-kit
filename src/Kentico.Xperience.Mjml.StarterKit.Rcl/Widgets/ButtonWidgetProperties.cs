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
        ExplanationText = "Select the button type")]
    public ButtonType ButtonType { get; set; } = ButtonType.Button;

    [DropDownComponent(
        Label = "Alignment",
        Order = 4,
        ExplanationText = "Select button alignment")]
    public ButtonAlignment Alignment { get; set; } = ButtonAlignment.Left;
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
