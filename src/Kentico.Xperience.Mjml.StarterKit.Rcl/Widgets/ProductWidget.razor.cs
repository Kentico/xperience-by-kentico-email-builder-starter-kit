using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(ProductWidget),
    name: "Product Widget",
    componentType: typeof(ProductWidget),
    PropertiesType = typeof(ProductWidgetProperties)
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public partial class ProductWidget : ComponentBase
{

}
