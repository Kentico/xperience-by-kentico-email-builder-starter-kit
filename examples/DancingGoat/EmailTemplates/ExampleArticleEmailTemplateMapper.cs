using CMS.ContentEngine;
using CMS.Websites;

using DancingGoat.Models;

using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace DancingGoat.EmailTemplates;

public class ExampleArticleEmailTemplateMapper : IArticleEmailTemplateMapper
{
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebPageQueryResultMapper webPageMapper;

    public string WebsiteChannelName { get; } = "DancingGoatPages";

    public ExampleArticleEmailTemplateMapper(IContentQueryExecutor contentQueryExecutor,
        IWebPageQueryResultMapper webPageMapper)
    {
        this.contentQueryExecutor = contentQueryExecutor;
        this.webPageMapper = webPageMapper;
    }

    public async Task<ArticleWidgetModel> MapProperties(Guid webPageItemGuid, string languageName)
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(ArticlePage.CONTENT_TYPE_NAME,
                config => config.WithLinkedItems(10)

                // Because the webPageItemGuid is a reusable content item, we don't have a website channel name to use here
                // so we use a hardcoded channel name.

                .ForWebsite(WebsiteChannelName)
                .Where(
                    x => x.WhereEquals(nameof(WebPageFields.WebPageItemGUID), webPageItemGuid)
                )
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
