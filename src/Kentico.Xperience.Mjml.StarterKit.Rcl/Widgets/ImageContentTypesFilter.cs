using Kentico.Xperience.Admin.Base.FormAnnotations;

using Microsoft.Extensions.Options;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Image content types filter.
/// </summary>
/// <param name="mjmlStarterKitOptions">The MJML starter kit options.</param>
internal sealed class ImageContentTypesFilter(IOptions<MjmlStarterKitOptions> mjmlStarterKitOptions)
    : IContentTypesFilter
{
    public IEnumerable<Guid> AllowedContentTypeIdentifiers { get; } =
        mjmlStarterKitOptions.Value.AllowedImageContentTypes;
}
