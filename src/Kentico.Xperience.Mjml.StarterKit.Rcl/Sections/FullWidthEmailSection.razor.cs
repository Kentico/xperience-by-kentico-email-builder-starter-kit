using Microsoft.AspNetCore.Components;
using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

[assembly: RegisterEmailSection(
    identifier: FullWidthEmailSection.IDENTIFIER,
    name: "Full Width Email Section",
    componentType: typeof(FullWidthEmailSection))]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

public partial class FullWidthEmailSection : ComponentBase
{
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(FullWidthEmailSection)}";
}
