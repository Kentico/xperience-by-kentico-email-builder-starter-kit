using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public sealed class HeroWidgetProperties : IEmailWidgetProperties
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
        Options = $"{nameof(Widgets.DescriptionPosition.Below)};{nameof(Widgets.DescriptionPosition.Below)}\r\n{nameof(Widgets.DescriptionPosition.Above)};{nameof(Widgets.DescriptionPosition.Above)}",
        OptionsValueSeparator = ";")]
    public string DescriptionPosition { get; set; } = nameof(Widgets.DescriptionPosition.Below);
}

public enum DescriptionPosition
{
    Above,
    Below
}
