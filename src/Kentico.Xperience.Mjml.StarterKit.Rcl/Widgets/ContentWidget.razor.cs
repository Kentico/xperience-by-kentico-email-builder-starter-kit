using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(ContentWidget),
    name: "Content Widget",
    componentType: typeof(ContentWidget),
    PropertiesType = typeof(ContentWidgetProperties),
    IconClass = "icon-l-list-article"
    )]
)]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Content widget component.
/// </summary>
public partial class ContentWidget : ComponentBase
{
    /// <summary>
    /// The widget properties.
    /// </summary>
    [Parameter]
    public ContentWidgetProperties Properties { get; set; } = null!;
}
