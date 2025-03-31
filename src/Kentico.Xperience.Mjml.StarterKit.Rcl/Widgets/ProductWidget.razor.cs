using CMS.Core;
using CMS.EventLog;
using CMS.Websites;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

using Microsoft.AspNetCore.Components;

[assembly: RegisterEmailWidget(
    identifier: ProductWidget.IDENTIFIER,
    name: "Product Widget",
    componentType: typeof(ProductWidget),
    PropertiesType = typeof(ProductWidgetProperties)
    )]

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Product widget component.
/// </summary>
public partial class ProductWidget : ComponentBase
{
    /// <summary>
    /// The component identifier.
    /// </summary>
    public const string IDENTIFIER = $"Kentico.Xperience.Mjml.StarterKit.{nameof(ProductWidget)}";

    [Inject]
    private IWidgetDataRetriever<ProductWidgetModel> ProductWidgetEmailMapper { get; set; } = default!;

    [Inject]
    private IWebPageUrlRetriever WebPageUrlRetriever { get; set; } = default!;

    [Inject]
    private IEmailContextAccessor EmailContextAccessor { get; set; } = default!;

    [Inject]
    private IEventLogService EventLogService { get; set; } = default!;

    /// <summary>
    /// The widget model.
    /// </summary>
    public ProductWidgetModel Model { get; set; } = new();

    /// <summary>
    /// The Web Page Item url which the widget is mapped to.
    /// </summary>
    public string WebPageItemUrl { get; set; } = string.Empty;

    /// <summary>
    /// The widget properties.
    /// </summary>
    [Parameter]
    public ProductWidgetProperties Properties { get; set; } = new();

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        var webPageItem = Properties.Pages.FirstOrDefault();

        if (webPageItem is null)
        {
            return;
        }

        string languageName = EmailContextAccessor.GetContext().LanguageName;

        var webPageItemUrl = await WebPageUrlRetriever.Retrieve(webPageItem.WebPageGuid, languageName);

        if (webPageItemUrl is not null)
        {
            WebPageItemUrl = webPageItemUrl.AbsoluteUrl;
        }

        Model = await ProductWidgetEmailMapper.MapProperties(webPageItem.WebPageGuid, languageName);

        if (Model is null)
        {
            EventLogService.LogError(nameof(ProductWidget), nameof(OnInitializedAsync), $"An attempt to use the {nameof(ProductWidget)} email builder widget component has been made, but the {nameof(IWidgetDataRetriever<ProductWidget>)} has not been registered.");
        }
    }
}
