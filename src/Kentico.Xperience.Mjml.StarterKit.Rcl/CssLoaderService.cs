using Kentico.Xperience.Mjml.StarterKit.Rcl;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

public class CssLoaderService
{
    private readonly IWebHostEnvironment enviroment;
    private readonly MjmlStarterKitOptions mjmlStarterKitOptions;

    public CssLoaderService(IWebHostEnvironment enviroment,
        IOptions<MjmlStarterKitOptions> mjmlStarterKitOptions)
    {
        this.enviroment = enviroment;
        this.mjmlStarterKitOptions = mjmlStarterKitOptions.Value;
    }

    public async Task<string> GetCssAsync()
    {
        string path = System.IO.Path.Combine(enviroment.WebRootPath, mjmlStarterKitOptions.EmailBuilderStyleSheetPath.TrimStart('/'));

        if (File.Exists(path))
        {
            string text = await File.ReadAllTextAsync(path);
            return text.Trim();
        }

        return "/* CSS not found */";
    }
}
