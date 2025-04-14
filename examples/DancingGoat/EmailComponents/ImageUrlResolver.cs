using CMS.ContentEngine;

namespace DancingGoat.EmailComponents;

internal sealed class ImageUrlResolver(IConfiguration configuration) : IImageUrlResolver
{
    private readonly string baseUrl = configuration.GetValue<string>(DancingGoatConstants.EMAILS_BASE_URL_KEY);

    public string ResolveImageUrl(ContentItemAsset? asset)
    {
        if (string.IsNullOrEmpty(baseUrl) || asset == null)
        {
            return string.Empty;
        }

        return $"{baseUrl.TrimEnd('/')}/{asset.Url.TrimStart('~')}";
    }
}
