using CMS.ContentEngine;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: ArticleWidget.IDENTIFIER,
    name: "Article Widget",
    componentType: typeof(ArticleWidget),
    PropertiesType = typeof(ArticleWidgetProperties)
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public partial class ArticleWidget : ComponentBase
{
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(ArticleWidget)}";

    [Inject]
    private IContentQueryExecutor ContentQueryExecutor { get; set; } = default!;

    public string Title { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (!Guid.TryParse(Properties.ContentItemGuid, out var contentItemGuid))
        {
            return;
        }

        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(MappingStorage.ArticleContentType,
                configuration => configuration
                .TopN(1)
                .Where(
                    x => x.WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), contentItemGuid)
                )
            );

        var result = await ContentQueryExecutor.GetResult(queryBuilder, selector =>
        {
            selector.TryGetValue(MappingStorage.ArticleTitleParameterName, out string articleTitle);
            selector.TryGetValue(MappingStorage.ArticleDescriptionParameterName, out string articleDescription);
            selector.TryGetValue(MappingStorage.ArticleImageUrlParamterName, out string articleImageUrl);
            return new
            {
                ArticleTitle = articleTitle,
                ArticleDescription = articleDescription,
                ArticleImageUrl = articleImageUrl
            };
        });

        var contentItem = result.FirstOrDefault();
        if (contentItem is not null)
        {
            Title = contentItem.ArticleTitle;
            Description = contentItem.ArticleDescription;
            ImageUrl = contentItem.ArticleImageUrl;
        }
    }
}
