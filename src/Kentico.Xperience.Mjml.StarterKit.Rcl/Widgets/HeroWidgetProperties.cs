using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public class HeroWidgetProperties : IEmailWidgetProperties
{
    [TextInputComponent(
        Label = "Image URL",
        Order = 1,
        ExplanationText = "Enter the URL of the hero image")]
    public string ImageUrl { get; set; } = string.Empty;

    [TextInputComponent(
        Label = "Alt Text",
        Order = 2,
        ExplanationText = "Enter alternative text for the image")]
    public string AltText { get; set; } = string.Empty;

    [TextAreaComponent(
        Label = "Description",
        Order = 3,
        ExplanationText = "Enter description text")]
    public string Description { get; set; } = string.Empty;

    [DropDownComponent(
        Label = "Description Position",
        Order = 4,
        ExplanationText = "Select where to display the description",
        Options = $"{nameof(DescriptionPosition.Below)};{nameof(DescriptionPosition.Below)}\r\n{nameof(DescriptionPosition.Above)};{nameof(DescriptionPosition.Above)}",
        OptionsValueSeparator = ";")]
    public string ButtonDescriptionPosition { get; set; } = nameof(DescriptionPosition.Below);

    [TextInputComponent(
        Label = "Border Radius",
        Order = 5,
        ExplanationText = "Enter border radius (e.g., '4px')")]
    public string BorderRadius { get; set; } = "0px";

    [TextInputComponent(
        Label = "Background Color",
        Order = 6,
        ExplanationText = "Enter background color (e.g., '#ffffff')")]
    public string BackgroundColor { get; set; } = "#ffffff";

    [TextInputComponent(
        Label = "Text Color",
        Order = 7,
        ExplanationText = "Enter text color for description")]
    public string TextColor { get; set; } = "#000000";
}

public enum DescriptionPosition
{
    Above,
    Below
}
