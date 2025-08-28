using CMS.Core;
using CMS.DataEngine;

using Kentico.Xperience.Admin.Websites;

using Microsoft.Extensions.Options;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Modifies the selectability of a web page panel item based on allowed product content types.
/// </summary>
/// <remarks>
/// This class ensures that only web page panel items with content types specified in <see cref="MjmlStarterKitOptions.AllowedProductContentTypes"/>
/// are marked as selectable. If a content type is not allowed, the item is marked as unselectable, and a localized
/// reason is provided.
/// </remarks>
internal sealed class ProductContentTypeSelectabilityModifier(IOptions<MjmlStarterKitOptions> mjmlStarterKitOptions, ILocalizationService localizationService) : IWebPagePanelItemModifier
{
    private readonly HashSet<string> allowedContentTypeCodeNames = new (mjmlStarterKitOptions.Value.AllowedProductContentTypes, StringComparer.OrdinalIgnoreCase);
    private readonly Dictionary<int, bool> allowedContentTypeIds = [];


    /// <inheritdoc/>
    public WebPagePanelItem Modify(WebPagePanelItem webPagePanelItem, WebPagePanelItemModifierParameters webPagePanelItemModifierParameters)
    {
        webPagePanelItem.SelectableOption.Selectable = IsSelectable(webPagePanelItemModifierParameters);
        webPagePanelItem.SelectableOption.UnselectableReason = localizationService.GetString("ProductWidget.Page.Notallowedtype.Unselectable");

        return webPagePanelItem;
    }


    private bool IsSelectable(WebPagePanelItemModifierParameters webPagePanelItemModifierParameters)
    {
        int contentTypeId = webPagePanelItemModifierParameters.WebPageMetadata.ContentTypeID;

        if (allowedContentTypeIds.TryGetValue(contentTypeId, out var isAllowed))
        {
            return isAllowed;
        }

        var className = DataClassInfoProvider.ProviderObject
            .Get(contentTypeId)?
            .ClassName;

        isAllowed = className is not null && allowedContentTypeCodeNames.Contains(className);
        allowedContentTypeIds[contentTypeId] = isAllowed;
        
        return isAllowed;
    }
}
