using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: ArticleWidget.IDENTIFIER,
    name: "Article Widget",
    componentType: typeof(ArticleWidget),
    PropertiesType = typeof(ArticleWidgetProperties)
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Article widget component.
/// </summary>
public partial class ArticleWidget : ComponentBase
{
    /// <summary>
    /// The component identifier.
    /// </summary>
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(ArticleWidget)}";

    [Inject]
    private IArticleEmailTemplateMapper ArticleEmailTemplateMapper { get; set; } = default!;

    /// <summary>
    /// The widget model.
    /// </summary>
    public ArticleWidgetModel Model { get; set; } = new();

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        var webPageItem = Properties.Pages.FirstOrDefault();

        if (webPageItem is null)
        {
            return;
        }

        Model = await ArticleEmailTemplateMapper.MapProperties(webPageItem.WebPageGuid);
    }
}
