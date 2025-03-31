using CMS.ContentEngine;
using CMS.Websites;

using DancingGoat.Models;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Templates;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

[assembly: RegisterEmailTemplate(
    identifier: ProductEmailTemplate.IDENTIFIER,
    name: "Email builder Product template",
    componentType: typeof(ProductEmailTemplate),
    ContentTypeNames = ["DancingGoat.Email"],
    Description = "Product template.",
    IconClass = "xp-c-sharp")
]

namespace DancingGoat.EmailTemplates;

public class ExampleProductEmailTemplateMapper : ProductEmailTemplateMapper
{
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebPageQueryResultMapper webPageMapper;

    public const string WEBSITE_CHANNEL_NAME = "DancingGoatPages";
    public const string WEBSITE_LANGUAGE_NAME = "en";

    public ExampleProductEmailTemplateMapper(IContentQueryExecutor contentQueryExecutor,
        IWebPageQueryResultMapper webPageMapper)
    {
        this.contentQueryExecutor = contentQueryExecutor;
        this.webPageMapper = webPageMapper;
    }

    public override async Task<ProductWidgetModel> MapProperties(Guid webPageItemGuid)
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(CoffeePage.CONTENT_TYPE_NAME,
                config => config.WithLinkedItems(10)
                .ForWebsite(WEBSITE_CHANNEL_NAME)
                .Where(
                    x => x.WhereEquals(nameof(WebPageFields.WebPageItemGUID), webPageItemGuid)
                )
            )
            .InLanguage(WEBSITE_LANGUAGE_NAME);

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
