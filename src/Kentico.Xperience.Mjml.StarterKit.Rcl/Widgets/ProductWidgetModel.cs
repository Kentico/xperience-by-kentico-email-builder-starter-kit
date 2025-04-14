namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// The product widget model.
/// </summary>
public sealed class ProductWidgetModel
{
    /// <summary>
    /// The product name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The product description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// The product image url.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;
    
    /// <summary>
    /// The product image alternate text.
    /// </summary>
    public string ImageAltText { get; set; } = string.Empty;

    /// <summary>
    /// The Web Page Item url which the widget is mapped to.
    /// </summary>
    public string Url { get; set; } = string.Empty;
}
