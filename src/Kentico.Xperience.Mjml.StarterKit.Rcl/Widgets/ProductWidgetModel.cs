namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// The product widget model.
/// </summary>
public sealed class ProductWidgetModel
{
    /// <summary>
    /// The title of the widget.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The text content of the widget.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// The Web Page Item url which the widget is mapped to.
    /// </summary>
    public string? WebPageItemUrl { get; set; }
}
