namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// Configuration options for the MJML Starter Kit.
/// </summary>
public sealed class MjmlStarterKitOptions
{
    /// <summary>
    /// The path of style sheets within the consuming application's wwwroot.
    /// </summary>
    public string StyleSheetPath { get; set; } = string.Empty;
  
    /// <summary>
    /// The list of content type identifiers that are allowed to be used in the Product Widget.
    /// </summary>
    public IEnumerable<Guid> AllowedProductContentTypes { get; set; } = Array.Empty<Guid>();
}
