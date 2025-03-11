using CMS.ContentEngine;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: ProductWidget.IDENTIFIER,
    name: "Product Widget",
    componentType: typeof(ProductWidget),
    PropertiesType = typeof(ProductWidgetProperties)
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public partial class ProductWidget : ComponentBase
{
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(ProductWidget)}";

    [Inject]
    private IContentQueryExecutor ContentQueryExecutor { get; set; } = default!;

    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        if (!Guid.TryParse(Properties.WebPageItemGuid, out var contentItemGuid))
        {
            return;
        }

        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(MappingStorage.ProductContentType,
                configuration => configuration
                .TopN(1)
                .Where(
                    x => x.WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), contentItemGuid)
                )
            );

        var result = await ContentQueryExecutor.GetResult(queryBuilder, selector =>
        {
            selector.TryGetValue(MappingStorage.ProductTitleParameterName, out string productTitle);
            selector.TryGetValue(MappingStorage.ProductContentPrameterName, out string productContent);
            return new
            {
                ProductTitle = productTitle,
                ProductContent = productContent
            };
        });

        var contentItem = result.FirstOrDefault();
        if (contentItem is not null)
        {
            Title = contentItem.ProductTitle;
            Content = contentItem.ProductContent;
        }
    }
}
