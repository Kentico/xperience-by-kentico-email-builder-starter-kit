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

namespace DancingGoat.EmailTemplates;

public class ExampleProductWidgetEmailDataRetriever : IWidgetDataRetriever<ProductWidgetModel>
{
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebPageQueryResultMapper webPageMapper;

    public ExampleProductWidgetEmailDataRetriever(IContentQueryExecutor contentQueryExecutor,
        IWebPageQueryResultMapper webPageMapper)
    {
        this.contentQueryExecutor = contentQueryExecutor;
        this.webPageMapper = webPageMapper;
    }

    public async Task<ProductWidgetModel> MapProperties(Guid webPageItemGuid, string languageName)
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentTypes(parameters => parameters
                .OfContentType(CoffeePage.CONTENT_TYPE_NAME)
                .ForWebsite([webPageItemGuid])
                .WithLinkedItems(10)
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
