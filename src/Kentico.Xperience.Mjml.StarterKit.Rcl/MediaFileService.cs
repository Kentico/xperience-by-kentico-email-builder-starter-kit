using CMS.DataEngine;
using CMS.MediaLibrary;

using Kentico.Content.Web.Mvc;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <summary>
/// Media file retriever and sanitizer helper service.
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

/// <inheritdoc/>
public class MediaFileService : IMediaFileService
{
    private readonly IInfoProvider<MediaFileInfo> mediaFileInfoProvider;
    private readonly IMediaFileUrlRetriever mediaFileUrlRetriever;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="mediaFileInfoProvider"></param>
    /// <param name="mediaFileUrlRetriever"></param>
    public MediaFileService(IInfoProvider<MediaFileInfo> mediaFileInfoProvider,
        IMediaFileUrlRetriever mediaFileUrlRetriever)
    {
        this.mediaFileInfoProvider = mediaFileInfoProvider;
        this.mediaFileUrlRetriever = mediaFileUrlRetriever;
    }

    /// <inheritdoc/>
    public string GetImageUrlFromMediaFileSelectorOrEmpty(IEnumerable<AssetRelatedItem> assets)
    {
        var imageIdentifier = assets.FirstOrDefault()?.Identifier;

        if (imageIdentifier is null)
        {
            return string.Empty;
        }

        return GetMediaFileUrl(imageIdentifier.Value)?.RelativePath.TrimStart('~') ?? string.Empty;
    }

    private IMediaFileUrl? GetMediaFileUrl(Guid identifier)
    {
        var mediaLibraryFiles = mediaFileInfoProvider
            .Get()
            .WhereEquals(nameof(MediaFileInfo.FileGUID), identifier);

        if (!mediaLibraryFiles.Any())
        {
            return null;
        }

        var media = mediaFileUrlRetriever.Retrieve(mediaLibraryFiles.First());

        return media;
    }
}
