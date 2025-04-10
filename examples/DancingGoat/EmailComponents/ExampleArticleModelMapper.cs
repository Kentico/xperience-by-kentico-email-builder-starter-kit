using CMS.ContentEngine;
using CMS.Websites;

using DancingGoat.Models;

using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace DancingGoat.EmailComponents;

public class ExampleArticleModelMapper : IComponentModelMapper<ArticleWidgetModel>
{
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebPageQueryResultMapper webPageMapper;

    public ExampleArticleModelMapper(IContentQueryExecutor contentQueryExecutor,
        IWebPageQueryResultMapper webPageMapper)
    {
        this.contentQueryExecutor = contentQueryExecutor;
        this.webPageMapper = webPageMapper;
    }

    public async Task<ArticleWidgetModel> Map(Guid webPageItemGuid, string languageName)
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentTypes(parameters => parameters
                .OfContentType(ArticlePage.CONTENT_TYPE_NAME)
                .ForWebsite([webPageItemGuid])
                .WithLinkedItems(10)
            )

            // Because the changedItem is a reusable content item, we don't have a language name to use here
            // so we use a hardcoded channel name.

            .InLanguage(languageName);

        var result = await contentQueryExecutor.GetWebPageResult(queryBuilder, webPageMapper.Map<ArticlePage>);
        var articlePage = result.FirstOrDefault();

        if (articlePage is null)
        {
            return new();
        }

        return new ArticleWidgetModel
        {
            Title = articlePage.ArticleTitle,
            Content = articlePage.ArticlePageSummary,
            ImageUrl = articlePage.ArticlePageTeaser.FirstOrDefault()?.ImageFile.Url ?? string.Empty
        };
    }
}
