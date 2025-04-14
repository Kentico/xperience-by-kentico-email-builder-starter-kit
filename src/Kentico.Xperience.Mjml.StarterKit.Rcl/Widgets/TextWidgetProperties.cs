using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="TextWidget"/>.
/// </summary>
public sealed class TextWidgetProperties : WidgetPropertiesBase
{
    /// <summary>
    /// The content text.
    /// </summary>
    [RichTextEditorComponent(
        Label = "{$TextWidget.Text.Label$}",
        Order = 1,
        ExplanationText = "{$TextWidget.Text.ExplanationText$}")]
    public string Text { get; set; } = string.Empty;
}
