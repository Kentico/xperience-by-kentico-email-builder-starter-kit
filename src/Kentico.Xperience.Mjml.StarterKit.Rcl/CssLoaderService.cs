using CMS.Helpers;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// Retriever of style sheets used for injection of CSS styles to Razor email builder components.
/// </summary>
public sealed class CssLoaderService
{
    private readonly IWebHostEnvironment environment;
    private readonly MjmlStarterKitOptions mjmlStarterKitOptions;
    private readonly IProgressiveCache progressiveCache;


    /// <summary>
    /// The <see cref="CssLoaderService"/> constructor.
    /// </summary>
    /// <param name="environment">The web hosting environment that provides information about the web application.</param>
    /// <param name="progressiveCache">The service providing optimization of parallel data loads.</param>
    /// <param name="mjmlStarterKitOptions">The configuration options for the MJML starter kit.</param>
    public CssLoaderService(IWebHostEnvironment environment,
                            IProgressiveCache progressiveCache,
                            IOptions<MjmlStarterKitOptions> mjmlStarterKitOptions)
    {
        this.environment = environment;
        this.progressiveCache = progressiveCache;
        this.mjmlStarterKitOptions = mjmlStarterKitOptions.Value;
    }

    /// <summary>
    /// Retrieves the style sheet specified by <see cref="MjmlStarterKitOptions.StyleSheetPath"/>.
    /// </summary>
    /// <seealso cref="MjmlStarterKitOptions"/>
    public string GetCss()
    {
        var settings = new CacheSettings(30, true, [nameof(CssLoaderService), nameof(GetCss)]);

        return progressiveCache.Load(cacheSettings => LoadCss(), settings);
    }


    private string LoadCss()
    {
        var path = CMS.IO.Path.Combine(environment.WebRootPath, mjmlStarterKitOptions.StyleSheetPath.TrimStart('/'));

        if (!CMS.IO.File.Exists(path))
        {
            return string.Empty;
        }

        var text = CMS.IO.File.ReadAllText(path);

        return text.Trim();
    }
}
