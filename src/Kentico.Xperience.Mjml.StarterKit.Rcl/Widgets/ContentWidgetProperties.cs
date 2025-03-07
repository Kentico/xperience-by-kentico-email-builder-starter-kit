using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public class ContentWidgetProperties : IEmailWidgetProperties
{
    [TextInputComponent(
        Label = "Content Text",
        Order = 1,
        ExplanationText = "Enter the text content for this widget")]
    public string Text { get; set; } = string.Empty;
}
