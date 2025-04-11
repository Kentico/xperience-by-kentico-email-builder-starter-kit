using CMS.ContentEngine;
using CMS.DataEngine;
using CMS.MediaLibrary;

using Kentico.Content.Web.Mvc;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

/// <inheritdoc/>
internal sealed class MediaFileService : IMediaFileService
{
    private readonly IInfoProvider<MediaFileInfo> mediaFileInfoProvider;
    private readonly IMediaFileUrlRetriever mediaFileUrlRetriever;

    /// <summary>
    /// Initializes a new instance of the <see cref="MediaFileService"/> class.
    /// </summary>
    /// <param name="mediaFileInfoProvider">The provider for media file information.</param>
    /// <param name="mediaFileUrlRetriever">The retriever for media file URLs.</param>
    public MediaFileService(IInfoProvider<MediaFileInfo> mediaFileInfoProvider,
        IMediaFileUrlRetriever mediaFileUrlRetriever)
    {
        this.mediaFileInfoProvider = mediaFileInfoProvider;
        this.mediaFileUrlRetriever = mediaFileUrlRetriever;
    }

    /// <inheritdoc/>
    public string GetFileUrl(AssetRelatedItem? asset)
    {
        var imageIdentifier = asset?.Identifier;

        if (imageIdentifier is null)
        {
            return string.Empty;
        }

        return GetMediaFileUrl(imageIdentifier.Value)?.RelativePath.TrimStart('~') ?? string.Empty;
    }

    public string GetFileUrl(ContentItemReference? asset)
    {
        var imageIdentifier = asset?.Identifier;
        
        if (imageIdentifier is null)
        {
            return string.Empty;
        }
        
        
        
        throw new NotImplementedException();
    }

    private IMediaFileUrl? GetMediaFileUrl(Guid identifier)
    {
        // var mediaLibraryFiles = mediaFileInfoProvider
        //     .Get()
        //     .WhereEquals(nameof(MediaFileInfo.FileGUID), identifier);
        //
        // if (!mediaLibraryFiles.Any())
        // {
        //     return null;
        // }

        var mediaLibraryFiles = mediaFileInfoProvider
            .Get()
            .WhereEquals(nameof(MediaFileInfo.FileGUID), identifier);

        if (!mediaLibraryFiles.Any())
        {
            return null;
        }
        
        var mediaFile = mediaFileInfoProvider.Get(identifier);
        //var media = mediaFileUrlRetriever.Retrieve(mediaLibraryFiles.First());
        var media = mediaFileUrlRetriever.Retrieve(mediaFile);

        return media;
    }
}
