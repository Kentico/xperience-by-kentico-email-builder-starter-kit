using Kentico.Xperience.Admin.Base.FormAnnotations;

using Microsoft.Extensions.Options;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

/// <summary>
/// Product content types filter.
/// </summary>
/// <param name="mjmlStarterKitOptions">The MJML starter kit options.</param>
internal sealed class ProductContentTypesFilter(IOptions<MjmlStarterKitOptions> mjmlStarterKitOptions)
    : IContentTypesFilter
{
    public IEnumerable<Guid> AllowedContentTypeIdentifiers { get; } =
        mjmlStarterKitOptions.Value.AllowedProductContentTypes;
}
