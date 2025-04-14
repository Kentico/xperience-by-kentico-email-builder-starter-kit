using CMS.ContentEngine;

namespace DancingGoat.EmailComponents;

public interface IImageUrlResolver
{
    string ResolveImageUrl(ContentItemAsset? asset);
}
