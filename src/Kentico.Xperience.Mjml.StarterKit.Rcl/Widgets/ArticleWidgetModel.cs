namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// The article widget model.
/// </summary>
public sealed class ArticleWidgetModel
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
    /// The URL of an image displayed in the widget.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;
}
