using CMS.DataEngine;
using CMS.MediaLibrary;

using Kentico.Content.Web.Mvc;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <inheritdoc/>
public sealed class MediaFileService : IMediaFileService
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
