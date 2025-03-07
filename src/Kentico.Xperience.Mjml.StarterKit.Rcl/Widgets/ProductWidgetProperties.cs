using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public class ProductWidgetProperties : IEmailWidgetProperties
{
    [TextInputComponent(
        Label = "Title",
        Order = 0,
        ExplanationText = "Enter the title.")]
    public string Title { get; set; } = string.Empty;

    [TextInputComponent(
        Label = "Text",
        Order = 1,
        ExplanationText = "Enter the content.")]
    public string Text { get; set; } = string.Empty;
}
