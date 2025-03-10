using Microsoft.AspNetCore.Components;
using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

[assembly: RegisterEmailSection(
    identifier: TwoColumnEmailSection.IDENTIFIER,
    name: "Two Columns Email Section",
    componentType: typeof(TwoColumnEmailSection))]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

public partial class TwoColumnEmailSection : ComponentBase
{
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(TwoColumnEmailSection)}";
}
