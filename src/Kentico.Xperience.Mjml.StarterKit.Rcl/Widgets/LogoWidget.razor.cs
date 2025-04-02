using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: LogoWidget.IDENTIFIER,
    name: "Logo Widget",
    componentType: typeof(LogoWidget),
    PropertiesType = typeof(LogoWidgetProperties),
    IconClass = "icon-l-lightbox"
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Logo widget component.
/// </summary>
public partial class LogoWidget : ComponentBase
{
    [Inject]
    private IMediaFileService MediaFileService { get; set; } = default!;

    /// <summary>
    /// The component identifier.
    /// </summary>
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(LogoWidget)}";

    /// <summary>
    /// Image url.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// The widget properties.
    /// </summary>
    [Parameter]
    public LogoWidgetProperties Properties { get; set; } = null!;

    /// <inheritdoc/>
    protected override void OnInitialized()
    => ImageUrl = MediaFileService.GetImageUrlFromMediaFileSelectorOrEmpty(Properties.Logo);
}

