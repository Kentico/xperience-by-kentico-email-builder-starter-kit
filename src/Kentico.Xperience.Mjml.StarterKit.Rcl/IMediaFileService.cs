using CMS.MediaLibrary;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// Service responsible for retrieving media file URLs from asset collections.
/// </summary>
public interface IMediaFileService
{
    /// <summary>
    /// Gets the file url of the first asset related item from the collection.
    /// </summary>
    /// <param name="assets">The asset collection.</param>
    /// <returns>The media file url or empty string.</returns>
    public string GetImageUrlFromMediaFileSelectorOrEmpty(IEnumerable<AssetRelatedItem> assets);
}
