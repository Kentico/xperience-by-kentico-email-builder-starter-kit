using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;

using Microsoft.AspNetCore.Components;

#pragma warning disable KXE0001
[assembly: RegisterEmailTemplate(
    identifier: "Kentico.Xperience.Mjml.StarterKit.Rcl.Templates.ProductEmailTemplate",
    name: "Email builder MJML template",
    componentType: typeof(SimpleEmailTemplate),
    ContentTypeNames = [$"{nameof(Kentico.Xperience.Mjml.StarterKit.Rcl.Templates)}.{nameof(ProductEmailTemplate)}"],
    Description = "Product template.",
    IconClass = "xp-c-sharp")]
#pragma warning restore KXE0001

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;

public partial class ProductEmailTemplate : ComponentBase
{

}
