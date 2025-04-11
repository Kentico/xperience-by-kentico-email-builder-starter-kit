using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(TextWidget),
    name: "{$TextWidget.Name$}",
    componentType: typeof(TextWidget),
    PropertiesType = typeof(TextWidgetProperties),
    IconClass = "icon-l-list-article",
    Description = "Displays text content in your email."
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Text widget component.
/// </summary>
public partial class TextWidget : ComponentBase
{
    /// <summary>
    /// The widget properties.
    /// </summary>
    [Parameter]
    public TextWidgetProperties Properties { get; set; } = null!;
    
    [Inject]
    private IEmailContextAccessor EmailContextAccessor { get; set; } = null!;
}
