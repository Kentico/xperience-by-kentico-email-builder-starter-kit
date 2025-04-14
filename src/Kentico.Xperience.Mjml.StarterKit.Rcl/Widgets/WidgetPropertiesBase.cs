using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public abstract class WidgetPropertiesBase : IEmailWidgetProperties
{
    /// <summary>
    /// The CSS class for this widget
    /// </summary>
    [TextInputComponent(
        Label = "{$WidgetPropertiesBase.CssClass.Label$}",
        Order = 100,
        ExplanationText = "{$WidgetPropertiesBase.CssClass.ExplanationText$}")]
    public string CssClass { get; set; } = string.Empty;
}
