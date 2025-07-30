using CMS.ContentEngine;
using CMS.Websites;

using DancingGoat;
using DancingGoat.Models;

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
/// <param name="executor">The content query executor for retrieving content items from the database.</param>
/// <param name="webPageUrlRetriever">The service for retrieving absolute URLs of web pages.</param>
internal class ExampleProductWidgetModelMapper(IContentQueryExecutor executor, IWebPageUrlRetriever webPageUrlRetriever)
    : IComponentModelMapper<ProductWidgetModel>
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
        var query = new ContentItemQueryBuilder()
            .ForContentTypes()
            .ForContentType(ProductPage.CONTENT_TYPE_NAME,
                config => config
                    .WithLinkedItems(10)
                    .ForWebsite(DancingGoatConstants.WEBSITE_CHANNEL_NAME, includeUrlPath: true)
                    .Where(where => where
                        .WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), itemGuid)))
            .InLanguage(languageName);

        var result = await executor.GetMappedResult<ProductPage>(query);

        var productPage = result.FirstOrDefault();

        if (productPage is null)
        {
            return new ProductWidgetModel();
        }

        var webPageItemUrl = await webPageUrlRetriever.Retrieve(productPage.SystemFields.WebPageItemID, languageName);

        var product = productPage.ProductPageProduct?.FirstOrDefault() as IProductFields;

        if (product is null)
        {
            return new ProductWidgetModel();
        }

        var image = product.ProductFieldImage.FirstOrDefault();

        return new ProductWidgetModel
        {
            Name = product.ProductFieldName,
            Description = product.ProductFieldDescription,
            Url = webPageItemUrl.AbsoluteUrl,
            ImageUrl = image?.ImageFile.Url,
            ImageAltText = image != null ? image.ImageShortDescription : string.Empty
        };
    }
}
