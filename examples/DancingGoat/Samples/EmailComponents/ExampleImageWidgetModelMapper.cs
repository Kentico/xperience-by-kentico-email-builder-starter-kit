using CMS.ContentEngine;

using DancingGoat.Models;

using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace Samples.DancingGoat;

public class ExampleImageWidgetModelMapper(IContentQueryExecutor executor) : IComponentModelMapper<ImageWidgetModel>
{
    public async Task<ImageWidgetModel> Map(Guid itemGuid, string languageName)
    {
        var query = new ContentItemQueryBuilder()
            .ForContentType(Image.CONTENT_TYPE_NAME,
                config => config
                    .Where(where => where.WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), itemGuid))
                    .TopN(1))
            .InLanguage(languageName);
        
        var result = await executor.GetMappedResult<Image>(query);

        var item = result?.FirstOrDefault();

        if (item is null)
        {
            return new ImageWidgetModel();
        }

        return new ImageWidgetModel()
        {
            ImageUrl = item.ImageFile?.Url,
            AltText = item.ImageShortDescription
        };
    }
}
