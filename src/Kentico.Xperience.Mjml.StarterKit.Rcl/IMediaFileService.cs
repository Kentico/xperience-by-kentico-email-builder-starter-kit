using CMS.ContentEngine;
using CMS.MediaLibrary;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// Service responsible for retrieving media file URLs from asset collections.
/// </summary>
internal interface IMediaFileService
{
    /// <summary>
    /// Gets the file url of the asset.
    /// </summary>
    /// <param name="asset">The asset.</param>
    /// <returns>The media file url or empty string.</returns>
    string GetFileUrl(AssetRelatedItem? asset);
}
