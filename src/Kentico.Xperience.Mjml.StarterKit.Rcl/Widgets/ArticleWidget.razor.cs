using CMS.Websites;

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
    private IWidgetDataRetriever<ArticleWidgetModel> ArticleWidgetEmailMapper { get; set; } = default!;

    [Inject]
    private IWebPageUrlRetriever WebPageUrlRetriever { get; set; } = default!;

    [Inject]
    private IEmailContextAccessor EmailContextAccessor { get; set; } = default!;

    /// <summary>
    /// The widget model.
    /// </summary>
    public ArticleWidgetModel Model { get; set; } = new();

    /// <summary>
    /// The Web Page Item url which the widget is mapped to.
    /// </summary>
    public string WebPageItemUrl { get; set; } = string.Empty;

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        var webPageItemGuid = Properties.Pages.FirstOrDefault();

        if (webPageItemGuid is null)
        {
            return;
        }

        string languageName = EmailContextAccessor.GetContext().LanguageName;

        var webPageItemUrl = await WebPageUrlRetriever.Retrieve(webPageItemGuid.WebPageGuid, languageName);

        if (webPageItemUrl is not null)
        {
            WebPageItemUrl = webPageItemUrl.AbsoluteUrl;
        }

        Model = await ArticleWidgetEmailMapper.MapProperties(webPageItemGuid.WebPageGuid, languageName);
    }
}
