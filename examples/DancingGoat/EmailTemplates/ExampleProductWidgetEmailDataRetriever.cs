using CMS.ContentEngine;
using CMS.Websites;

using DancingGoat.Models;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

#pragma warning disable KXE0001
[assembly: RegisterEmailTemplate(
    identifier: ProductEmailTemplate.IDENTIFIER,
    name: "Mjml starter kit template",
    componentType: typeof(ProductEmailTemplate),
    ContentTypeNames = ["DancingGoat.Email"],
    Description = "Product template.",
    IconClass = "xp-c-sharp")
]
#pragma warning restore KXE0001

namespace DancingGoat.EmailTemplates;

public class ExampleProductWidgetEmailDataRetriever : WidgetDataRetriever<ProductWidgetModel>
{
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebPageQueryResultMapper webPageMapper;

    public string WebsiteChannelName { get; } = "DancingGoatPages";

    public ExampleProductWidgetEmailDataRetriever(IContentQueryExecutor contentQueryExecutor,
        IWebPageQueryResultMapper webPageMapper)
    {
        this.contentQueryExecutor = contentQueryExecutor;
        this.webPageMapper = webPageMapper;
    }

    public async Task<ProductWidgetModel> MapProperties(Guid webPageItemGuid, string languageName)
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(CoffeePage.CONTENT_TYPE_NAME,
                config => config.WithLinkedItems(10)
                .ForWebsite(WebsiteChannelName)
                .Where(
                    x => x.WhereEquals(nameof(WebPageFields.WebPageItemGUID), webPageItemGuid)
                )
            )
            .InLanguage(languageName);

        var result = await contentQueryExecutor.GetWebPageResult(queryBuilder, webPageMapper.Map<CoffeePage>);
        var coffeePage = result.FirstOrDefault();

        if (coffeePage is null)
        {
            return new();
        }

        var coffee = coffeePage.RelatedItem?.FirstOrDefault();
        if (coffee is null)
        {
            return new();
        }

        return new ProductWidgetModel
        {
            Title = coffee.ProductFieldsName,
            Content = coffee.ProductFieldsDescription
        };
    }
}
