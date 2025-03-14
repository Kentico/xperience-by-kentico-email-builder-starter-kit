using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="ContentWidget"/>.
/// </summary>
public class ContentWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// The content text.
    /// </summary>
    [RichTextEditorComponent(
        Label = "Content Text",
        Order = 1,
        ExplanationText = "Enter the content for this widget")]
    public string Text { get; set; } = string.Empty;
}
