using CMS.Websites;

using DancingGoat;
using DancingGoat.Models;

using Kentico.Content.Web.Mvc;
using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

[assembly: RegisterEmailTemplate(
    identifier: EmailBuilderStarterKitTemplate.IDENTIFIER,
    name: "Mjml starter kit template",
    componentType: typeof(EmailBuilderStarterKitTemplate),
    ContentTypeNames = ["DancingGoat.Email"],
    Description = "Email builder starter kit template.",
    IconClass = "xp-c-sharp")
]

namespace Samples.DancingGoat;

/// <summary>
/// Maps product page content items to ProductWidgetModel for use in email builder product widgets.
/// Retrieves product information including name, description, image, and URL from the Dancing Goat
/// content model and transforms it into the format required by the email builder's product widget component.
/// </summary>
/// <param name="contentRetriever">The content retriever service for retrieving content items from the database.</param>
internal class ExampleProductWidgetModelMapper(IContentRetriever contentRetriever) : IComponentModelMapper<ProductWidgetModel>
{
    /// <summary>
    /// Maps a product page content item identified by GUID to a ProductWidgetModel containing
    /// all necessary product information for email rendering including name, description, image, and URL.
    /// </summary>
    /// <param name="itemGuid">The unique identifier of the product page content item to retrieve and map.</param>
    /// <param name="languageName">The language variant name for localized content retrieval.</param>
    /// <returns>
    /// A ProductWidgetModel containing the mapped product data including name, description, image URL,
    /// image alt text, and absolute URL. Returns an empty model if the item or associated product is not found.
    /// </returns>
    public async Task<ProductWidgetModel> Map(Guid itemGuid, string languageName)
    {
        if (itemGuid == Guid.Empty)
        {
            return new ProductWidgetModel();
        }

        var parameters = new RetrievePagesParameters()
        {
            ChannelName = DancingGoatConstants.WEBSITE_CHANNEL_NAME,
            IncludeUrlPath = true,
            LanguageName = languageName,
            LinkedItemsMaxLevel = 10,
            IsForPreview = false
        };

        var cacheKeySuffix = $"{nameof(RetrieveContentQueryParameters.TopN)}|1";
        var cacheSettings = new RetrievalCacheSettings(cacheKeySuffix, cacheExpiration: TimeSpan.FromMinutes(1), useSlidingExpiration: true);

        var result = await contentRetriever.RetrievePagesByGuids<ProductPage>([itemGuid], parameters, query => query.TopN(1), cacheSettings);

        var productPage = result.FirstOrDefault();
        var product = productPage?.ProductPageProduct?.FirstOrDefault() as IProductFields;

        if (productPage is null || product is null)
        {
            return new ProductWidgetModel();
        }

        var absoluteUrl = productPage.GetUrl().AbsoluteUrl;
        var image = product.ProductFieldImage.FirstOrDefault();

        return new ProductWidgetModel
        {
            Name = product.ProductFieldName,
            Description = product.ProductFieldDescription,
            Url = absoluteUrl,
            ImageUrl = image?.ImageFile.Url,
            ImageAltText = image != null ? image.ImageShortDescription : string.Empty
        };
    }
}
