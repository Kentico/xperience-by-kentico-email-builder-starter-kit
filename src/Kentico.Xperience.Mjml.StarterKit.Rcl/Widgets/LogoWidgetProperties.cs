using CMS.MediaLibrary;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Configurable properties of the <see cref="LogoWidget"/>.
/// </summary>
public class LogoWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// The logo.
    /// </summary>
    [AssetSelectorComponent(Label = "Logo", Order = 1, ExplanationText = "Logo from a library.", AllowedExtensions = "jpg;jpeg;png", MaximumAssets = 1)]
    public IEnumerable<AssetRelatedItem> Logo { get; set; } = [];
}
