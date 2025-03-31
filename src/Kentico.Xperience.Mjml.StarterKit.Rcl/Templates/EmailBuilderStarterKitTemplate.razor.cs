using CMS.EmailEngine;

using Kentico.EmailBuilder.Web.Mvc;

using Microsoft.AspNetCore.Components;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;

/// <summary>
/// The product email template component.
/// </summary>
public partial class EmailBuilderStarterKitTemplate : ComponentBase
{
    private string cssContent = string.Empty;
    private string emailSubject = string.Empty;

    [Inject]
    private CssLoaderService CssLoaderService { get; set; } = default!;

    [Inject]
    private IEmailContextAccessor EmailContextAccessor { get; set; } = default!;

    /// <summary>
    /// The component identifier.
    /// </summary>
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(EmailBuilderStarterKitTemplate)}";

    protected override async Task OnInitializedAsync()
    {
        emailSubject = (string)EmailContextAccessor.GetContext().EmailFields[nameof(EmailInfo.EmailSubject)];
        cssContent = await CssLoaderService.GetCssAsync();
    }
}
