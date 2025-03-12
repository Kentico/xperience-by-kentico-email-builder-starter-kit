using CMS.ContentEngine;
using CMS.Websites;

using DancingGoat.Models;

using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace DancingGoat.EmailTemplates;

public class ExampleArticleEmailTemplateMapper : ArticleEmailTemplateMapper
{
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebPageQueryResultMapper webPageMapper;

    public const string WEBSITE_CHANNEL_NAME = "DancingGoatPages";
    public const string WEBSITE_LANGUAGE_NAME = "en";

    public ExampleArticleEmailTemplateMapper(IContentQueryExecutor contentQueryExecutor,
        IWebPageQueryResultMapper webPageMapper)
    {
        this.contentQueryExecutor = contentQueryExecutor;
        this.webPageMapper = webPageMapper;
    }

    public override string WebPageItemSelectorDisplayedMessage { get; set; } = string.Empty;

    public override async Task<ArticleWidgetModel> MapProperties(Guid webPageItemGuid)
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(ArticlePage.CONTENT_TYPE_NAME,
                config => config.WithLinkedItems(10)
                .ForWebsite(WEBSITE_CHANNEL_NAME)
                .Where(
                    x => x.WhereEquals(nameof(WebPageFields.WebPageItemGUID), webPageItemGuid)
                )
            )
            .InLanguage(WEBSITE_LANGUAGE_NAME);

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
