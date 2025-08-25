using CMS.ContentEngine;

using DancingGoat.Models;

using Kentico.Content.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace Samples.DancingGoat;

/// <summary>
/// Maps content items to ImageWidgetModel for use in email builder image widgets.
/// Retrieves image content from the Dancing Goat content model and transforms it
/// into the format required by the email builder's image widget component.
/// </summary>
/// <param name="contentRetriever">The content retriever service for retrieving content items from the database.</param>
public class ExampleImageWidgetModelMapper(IContentRetriever contentRetriever) : IComponentModelMapper<ImageWidgetModel>
{
    /// <summary>
    /// Maps a content item identified by GUID to an ImageWidgetModel containing
    /// the image URL and alternative text for email rendering.
    /// </summary>
    /// <param name="itemGuid">The unique identifier of the content item to retrieve and map.</param>
    /// <param name="languageName">The language variant name for localized content retrieval.</param>
    /// <returns>
    /// An ImageWidgetModel containing the mapped image data, or an empty model if the item is not found.
    /// </returns>
    public async Task<ImageWidgetModel> Map(Guid itemGuid, string languageName)
    {
        var cacheKeySuffix = $"{nameof(RetrieveContentQueryParameters.Where)}|{itemGuid}|{nameof(RetrieveContentQueryParameters.TopN)}|1";
        var cacheSettings = new RetrievalCacheSettings(cacheKeySuffix, TimeSpan.FromMinutes(30), useSlidingExpiration: true);

        var parameters = new RetrieveContentParameters()
        {
            LanguageName = languageName,
            IsForPreview = false
        };

        var result = await contentRetriever.RetrieveContent<Image>(parameters,
                                                                   query => query.Where(where => where.WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), itemGuid))
                                                                                 .TopN(1),
                                                                   cacheSettings);

        var item = result?.FirstOrDefault();

        if (item is null)
        {
            return new ImageWidgetModel();
        }

        return new ImageWidgetModel()
        {
            ImageUrl = item.ImageFile?.Url,
            AltText = item.ImageShortDescription
        };
    }
}
