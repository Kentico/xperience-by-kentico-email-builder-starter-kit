using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(DividerWidget),
    name: "{$DividerWidget.Name$}",
    componentType: typeof(DividerWidget),
    PropertiesType = typeof(DividerWidgetProperties),
    IconClass = "icon-ellipsis",
    Description = "{$DividerWidget.Description$}"
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
