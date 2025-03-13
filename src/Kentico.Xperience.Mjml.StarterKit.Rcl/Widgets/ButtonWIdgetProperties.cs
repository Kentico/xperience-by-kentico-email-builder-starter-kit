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

    [TextInputComponent(
        Label = "Background Color",
        Order = 4,
        ExplanationText = "Enter background color (e.g., '#007bff')")]
    public string BackgroundColor { get; set; } = "#007bff";

    [TextInputComponent(
        Label = "Text Color",
        Order = 5,
        ExplanationText = "Enter text color")]
    public string TextColor { get; set; } = "#ffffff";

    [TextInputComponent(
        Label = "Border Radius",
        Order = 6,
        ExplanationText = "Enter border radius (e.g., '4px')")]
    public string BorderRadius { get; set; } = "4px";

    [TextInputComponent(
        Label = "Padding",
        Order = 7,
        ExplanationText = "Enter padding (e.g., '10px 20px')")]
    public string Padding { get; set; } = "10px 20px";

    [TextInputComponent(
        Label = "Font Size",
        Order = 8,
        ExplanationText = "Enter font size")]
    public string FontSize { get; set; } = "16px";

    [TextInputComponent(
        Label = "Font Weight",
        Order = 9,
        ExplanationText = "Enter font weight (e.g., 'normal', 'bold')")]
    public string FontWeight { get; set; } = "normal";

    [CheckBoxComponent(
        Label = "Full Width",
        Order = 10,
        ExplanationText = "Make button full width")]
    public bool FullWidth { get; set; }

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
