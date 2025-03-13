namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// The options defined in the appsettings.json.
/// </summary>
public sealed class MjmlStarterKitOptions
{
    /// <summary>
    /// The path of style sheets within the consuming application's wwwroot.
    /// </summary>
    public string EmailBuilderStyleSheetPath { get; set; } = string.Empty;
}
