using Microsoft.AspNetCore.Components;
using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

[assembly: RegisterEmailSection(
    identifier: $"{nameof(Kentico.Xperience.Mjml.StarterKit.Rcl.Sections)}.{nameof(SimpleEmailSection)}",
    name: "Simple section",
    componentType: typeof(SimpleEmailSection))]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

public partial class SimpleEmailSection : ComponentBase
{

}
