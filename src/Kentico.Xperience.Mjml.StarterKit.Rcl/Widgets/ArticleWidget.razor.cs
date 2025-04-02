using CMS.Core;
using CMS.Websites;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;

[assembly: RegisterEmailWidget(
    identifier: ArticleWidget.IDENTIFIER,
    name: "Article Widget",
    componentType: typeof(ArticleWidget),
    PropertiesType = typeof(ArticleWidgetProperties),
    IconClass = "icon-l-list-img-article"
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
    private IWidgetDataRetriever<ArticleWidgetModel> ArticleWidgetDataRetriever { get; set; } = default!;

    [Inject]
    private IWebPageUrlRetriever WebPageUrlRetriever { get; set; } = default!;

    [Inject]
    private IEmailContextAccessor EmailContextAccessor { get; set; } = default!;

    [Inject]
    private IEventLogService EventLogService { get; set; } = default!;

    [Inject]
    private IHttpContextAccessor HttpContextAccessor { get; set; } = default!;

    private string ImageUrl { get; set; } = string.Empty;

    /// <summary>
    /// The widget model.
    /// </summary>
    public ArticleWidgetModel Model { get; set; } = new();

    /// <summary>
    /// The Web Page Item url which the widget is mapped to.
    /// </summary>
    public string WebPageItemUrl { get; set; } = string.Empty;

    /// <summary>
    /// The widget properties.
    /// </summary>
    [Parameter]
    public ArticleWidgetProperties Properties { get; set; } = new();

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

        Model = await ArticleWidgetDataRetriever.MapProperties(webPageItemGuid.WebPageGuid, languageName);

        if (Model is null)
        {
            EventLogService.LogError(nameof(ArticleWidget), nameof(OnInitializedAsync), $"An attempt to use the {nameof(ArticleWidget)} email builder widget component has been made, but the {nameof(IWidgetDataRetriever<ArticleWidgetModel>)} has not been registered.");
            return;
        }

        if (HttpContextAccessor.HttpContext is not null && !string.IsNullOrWhiteSpace(Model.ImageUrl))
        {
            var request = HttpContextAccessor.HttpContext.Request;
            ImageUrl = $"{request.Scheme}://{request.Host}{Model.ImageUrl.TrimStart('~')}";
        }
    }
}
