using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;

using Microsoft.AspNetCore.Components;

#pragma warning disable KXE0001
[assembly: RegisterEmailTemplate(
    identifier: ProductEmailTemplate.IDENTIFIER,
    name: "Email builder Product template",
    componentType: typeof(ProductEmailTemplate),
    ContentTypeNames = ["Kbank.NewsletterEmail", "Kbank.SimpleEmail", "Kbank.PromotionEmail"],
    Description = "Product template.",
    IconClass = "xp-c-sharp")
]
#pragma warning restore KXE0001

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;

public partial class ProductEmailTemplate : ComponentBase
{
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(ProductEmailTemplate)}";
}
