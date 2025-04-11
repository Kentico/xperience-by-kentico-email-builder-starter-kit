using CMS.ContentEngine;

using DancingGoat.Models;

using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace DancingGoat.EmailComponents;

public class ExampleImageWidgetModelMapper(IContentQueryExecutor executor) : IComponentModelMapper<ImageWidgetModel>
{
    public async Task<ImageWidgetModel> Map(Guid webPageItemGuid, string languageName)
    {
        var query = new ContentItemQueryBuilder()
            .ForContentType(Image.CONTENT_TYPE_NAME,
                config => config
                    .Where(where => where.WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), webPageItemGuid))
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
            #warning fix url resolving
            ImageUrl  = $"https://localhost:60303{item.ImageFile.Url.TrimStart('~')}",
            AltText = item.ImageShortDescription
        };
    }
}
