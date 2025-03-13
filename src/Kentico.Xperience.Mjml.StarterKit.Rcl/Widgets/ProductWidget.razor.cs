using CMS.ContentEngine;

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
    private IProductEmailTemplateMapper ProductEmailTemplateMapper { get; set; } = default!;

    /// <summary>
    /// The widget model.
    /// </summary>
    public ProductWidgetModel Model { get; set; } = new();

    /// <inheritdoc />
    protected override async Task OnInitializedAsync()
    {
        var webPageItem = Properties.Pages.FirstOrDefault();

        if (webPageItem is null)
        {
            return;
        }

        Model = await ProductEmailTemplateMapper.MapProperties(webPageItem.WebPageGuid);
    }
}
