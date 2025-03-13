using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(ContentWidget),
    name: "Content Widget",
    componentType: typeof(ContentWidget),
    PropertiesType = typeof(ContentWidgetProperties)
)]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public partial class ContentWidget : ComponentBase
{
}
