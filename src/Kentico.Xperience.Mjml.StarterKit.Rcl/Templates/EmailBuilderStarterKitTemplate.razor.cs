using CMS.EmailEngine;

using Kentico.EmailBuilder.Web.Mvc;

using Microsoft.AspNetCore.Components;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;

/// <summary>
/// The email starter kit template component.
/// </summary>
public partial class EmailBuilderStarterKitTemplate : ComponentBase
{
    protected string CssContent { get; set; } = string.Empty;
    protected string EmailSubject { get; set; } = string.Empty;

    [Inject]
    private CssLoaderService CssLoaderService { get; set; } = null!;

    [Inject]
    private IEmailContextAccessor EmailContextAccessor { get; set; } = null!;

    /// <summary>
    /// The component identifier.
    /// </summary>
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(EmailBuilderStarterKitTemplate)}";

    protected override async Task OnInitializedAsync()
    {
        EmailSubject = (string)EmailContextAccessor.GetContext().EmailFields[nameof(EmailInfo.EmailSubject)];
        CssContent = await CssLoaderService.GetCssAsync();
    }
}
