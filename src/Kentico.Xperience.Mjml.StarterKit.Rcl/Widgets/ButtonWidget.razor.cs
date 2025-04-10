using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(ButtonWidget),
    name: "Button",
    componentType: typeof(ButtonWidget),
    PropertiesType = typeof(ButtonWidgetProperties),
    IconClass = "icon-triangle-right",
    Description = "Displays a button with a link to a web page."
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Button widget component.
/// </summary>
public partial class ButtonWidget : ComponentBase
{
    /// <summary>
    /// The widget properties.
    /// </summary>
    [Parameter]
    public ButtonWidgetProperties Properties { get; set; } = null!;
}
