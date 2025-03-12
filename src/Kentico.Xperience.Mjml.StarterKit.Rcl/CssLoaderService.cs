using Microsoft.AspNetCore.Hosting;

public class CssLoaderService
{
    private readonly IWebHostEnvironment enviroment;


    public CssLoaderService(IWebHostEnvironment enviroment)
        => this.enviroment = enviroment;

    public async Task<string> GetCssAsync()
    {
        string path = System.IO.Path.Combine(enviroment.WebRootPath, relativePath.TrimStart('/'));

        if (File.Exists(path))
        {
            string text = await File.ReadAllTextAsync(path);
            return text.Trim();
        }

        return "/* CSS not found */";
    }
}
