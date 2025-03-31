using Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

using Microsoft.AspNetCore.Components;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;

/// <summary>
/// The product email template component.
/// </summary>
public partial class ProductEmailTemplate : ComponentBase
{
    private string cssContent = string.Empty;

    private readonly string sectionIdentifier = FullWidthEmailSection.IDENTIFIER;

    /// <summary>
    /// The component identifier.
    /// </summary>
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(ProductEmailTemplate)}";

    protected override async Task OnInitializedAsync() => cssContent = await CssLoaderService.GetCssAsync();
}
