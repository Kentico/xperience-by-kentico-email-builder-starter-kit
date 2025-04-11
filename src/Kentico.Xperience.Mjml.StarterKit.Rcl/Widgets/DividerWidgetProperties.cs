using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets.Enums;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ButtonWidget"/>.
/// </summary>
public sealed class DividerWidgetProperties : WidgetPropertiesBase
{
    /// <summary>
    /// The border width.
    /// </summary>
    [NumberInputComponent(Label = "BorderWidth", Order = 3)]
    public int BorderWidth { get; set; } = 1;
    
    /// <summary>
    /// The border color.
    /// </summary>
    [TextInputComponent(
        Label = "Border color",
        Order = 2)]
    public string BorderColor { get; set; } = string.Empty;

    /// <summary>
    /// The style of the border.
    /// </summary>
    [TextInputComponent(
        Label = "Border style",
        Order = 3,
        ExplanationText = "You can specify the border style here (dashed/dotted/solid).")]
    public string BorderStyle { get; set; } = string.Empty;
}
