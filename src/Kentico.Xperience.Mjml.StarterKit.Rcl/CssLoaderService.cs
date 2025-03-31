using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// Retriever of style sheets used for injection of css styles to razor email builder components.
/// </summary>
public class CssLoaderService
{
    private readonly IWebHostEnvironment environment;
    private readonly MjmlStarterKitOptions mjmlStarterKitOptions;

    /// <summary>
    /// The <see cref="CssLoaderService"/> constructor.
    /// </summary>
    /// <param name="environment"></param>
    /// <param name="mjmlStarterKitOptions"></param>
    public CssLoaderService(IWebHostEnvironment environment,
        IOptions<MjmlStarterKitOptions> mjmlStarterKitOptions)
    {
        this.environment = environment;
        this.mjmlStarterKitOptions = mjmlStarterKitOptions.Value;
    }

    /// <summary>
    /// Retrieves the style sheet from the location specified in the appsettings.json.
    /// </summary>
    /// <returns></returns>
    public async Task<string> GetCssAsync()
    {
        string path = CMS.IO.Path.Combine(environment.WebRootPath, mjmlStarterKitOptions.EmailBuilderStyleSheetPath.TrimStart('/'));

        if (File.Exists(path))
        {
            string text = await File.ReadAllTextAsync(path);
            return text.Trim();
        }

        return string.Empty;
    }
}
