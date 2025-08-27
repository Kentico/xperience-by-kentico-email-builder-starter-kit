using CMS.Core;
using CMS.DataEngine;

using Kentico.Xperience.Admin.Websites;

using Microsoft.Extensions.Options;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Product content types filter.
/// </summary>
internal sealed class ProductContentTypesFilter : IWebPagePanelItemModifier
{
    private readonly IEnumerable<string> allowedContentTypeCodeNames;
    private readonly ILocalizationService localizationService;

    /// <summary>
    /// Product content types filter.
    /// </summary>
    /// <param name="mjmlStarterKitOptions">The MJML starter kit options.</param>
    /// <param name="localizationService">The system localization service.</param>
    public ProductContentTypesFilter(IOptions<MjmlStarterKitOptions> mjmlStarterKitOptions, ILocalizationService localizationService)
    {
        allowedContentTypeCodeNames = mjmlStarterKitOptions.Value.AllowedProductContentTypes;

        this.localizationService = localizationService;
    }


    /// <inheritdoc/>
    public WebPagePanelItem Modify(WebPagePanelItem webPagePanelItem, WebPagePanelItemModifierParameters webPagePanelItemModifierParameters)
    {
        webPagePanelItem.SelectableOption.Selectable = IsSelectable(webPagePanelItemModifierParameters);
        webPagePanelItem.SelectableOption.UnselectableReason = localizationService.GetString("ProductWidget.Page.Notallowedtype.Unselectable");
        return webPagePanelItem;
    }


    private bool IsSelectable(WebPagePanelItemModifierParameters webPagePanelItemModifierParameters)
    {
        var allowedContentTypeIdentifiers = DataClassInfoProvider.ProviderObject.Get().Where(c => allowedContentTypeCodeNames.Contains(c.ClassName)).Select(c => c.ClassID);

        return allowedContentTypeIdentifiers.Contains(webPagePanelItemModifierParameters.WebPageMetadata.ContentTypeID);
    }
}
