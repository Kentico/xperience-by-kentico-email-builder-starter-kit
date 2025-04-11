using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="TextWidget"/>.
/// </summary>
public sealed class TextWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// The content text.
    /// </summary>
    [RichTextEditorComponent(
        Label = "Text",
        Order = 1,
        ExplanationText = "{$TextWidget.Description$}")] //Enter the content for this widget
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// The CSS class for this text block
    /// </summary>
    [TextInputComponent(
        Label = "CSS class",
        Order = 2,
        ExplanationText = "CSS class for this text block.")]
    public string CssClass { get; set; } = string.Empty;
}
