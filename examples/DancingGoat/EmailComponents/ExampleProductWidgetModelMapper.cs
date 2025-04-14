using CMS.ContentEngine;
using CMS.Websites;

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

namespace DancingGoat.EmailComponents;

internal class ExampleProductWidgetModelMapper(IContentQueryExecutor executor, IWebPageUrlRetriever webPageUrlRetriever, IImageUrlResolver imageUrlResolver)
    : IComponentModelMapper<ProductWidgetModel>
{
    public async Task<ProductWidgetModel> Map(Guid webPageItemGuid, string languageName)
    {
        var query = new ContentItemQueryBuilder()
            .ForContentType(CoffeePage.CONTENT_TYPE_NAME,
                config => config
                    .WithLinkedItems(10)
                    .ForWebsite(DancingGoatConstants.WEBSITE_CHANNEL_NAME, includeUrlPath: true)
                    .Where(where => where
                        .WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), webPageItemGuid)))
            .InLanguage(languageName);

        var result = await executor.GetMappedResult<CoffeePage>(query);
        
        var coffeePage = result.FirstOrDefault();

        if (coffeePage is null)
        {
            return new ProductWidgetModel();
        }

        var webPageItemUrl = await webPageUrlRetriever.Retrieve(coffeePage.SystemFields.WebPageItemID, languageName);

        var coffee = coffeePage.RelatedItem?.FirstOrDefault();
        
        if (coffee is null)
        {
            return new ProductWidgetModel();
        }
        
        var image = coffee.ProductFieldsImage.FirstOrDefault();

        return new ProductWidgetModel
        {
            Name = coffee.ProductFieldsName,
            Description = coffee.ProductFieldsDescription,
            Url = webPageItemUrl.AbsoluteUrl,
            ImageUrl = imageUrlResolver.ResolveImageUrl(image?.ImageFile),
            ImageAltText = image != null ? image.ImageShortDescription : string.Empty
        };
    }
}
