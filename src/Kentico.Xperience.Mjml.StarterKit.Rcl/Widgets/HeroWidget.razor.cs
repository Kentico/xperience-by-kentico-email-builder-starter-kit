using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: nameof(HeroWidget),
    name: "Hero Widget",
    componentType: typeof(HeroWidget),
    PropertiesType = typeof(HeroWidgetProperties)
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public partial class HeroWidget : ComponentBase
{
}

