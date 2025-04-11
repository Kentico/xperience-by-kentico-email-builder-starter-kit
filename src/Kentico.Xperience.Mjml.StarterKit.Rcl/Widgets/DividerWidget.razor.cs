using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(DividerWidget),
    name: "Divider",
    componentType: typeof(DividerWidget),
    PropertiesType = typeof(DividerWidgetProperties),
    IconClass = "icon-triangle-right",
    Description = "Displays a divider."
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Divider widget component.
/// </summary>
public partial class DividerWidget : ComponentBase
{
    /// <summary>
    /// The divider properties.
    /// </summary>
    [Parameter]
    public DividerWidgetProperties Properties { get; set; } = null!;
}
