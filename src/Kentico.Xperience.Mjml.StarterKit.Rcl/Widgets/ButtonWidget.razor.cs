using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(ButtonWidget),
    name: "Button Widget",
    componentType: typeof(ButtonWidget),
    PropertiesType = typeof(ButtonWidgetProperties)
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Button widget component.
/// </summary>
public partial class ButtonWidget : ComponentBase
{
}
