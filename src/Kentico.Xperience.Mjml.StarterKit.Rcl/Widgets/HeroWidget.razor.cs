using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: HeroWidget.IDENTIFIER,
    name: "Hero",
    componentType: typeof(HeroWidget),
    PropertiesType = typeof(HeroWidgetProperties),
    IconClass = "icon-l-lightbox",
    Description = "Displays a hero image with a title and a text content."
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Hero widget component.
/// </summary>
public partial class HeroWidget : ComponentBase
{
    [Inject]
    private IMediaFileService MediaFileService { get; set; } = default!;

    /// <summary>
    /// The component identifier.
    /// </summary>
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(HeroWidget)}";

    /// <summary>
    /// Image url.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// The widget properties.
    /// </summary>
    [Parameter]
    public HeroWidgetProperties Properties { get; set; } = null!;

    /// <inheritdoc/>
    protected override void OnInitialized()
    => ImageUrl = MediaFileService.GetFileUrl(Properties.Image.FirstOrDefault());
}

