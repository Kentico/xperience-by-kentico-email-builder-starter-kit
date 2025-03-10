
using CMS.ContentEngine;

using Kentico.Xperience.Admin.Base.FormAnnotations;

using Microsoft.Extensions.DependencyInjection;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl;

public static class MjmlStarterKitStartupExtensions
{
    public static IServiceCollection AddMjmlStarterKit(this IServiceCollection serviceCollection, Action<Mapper> configure)
    {
        var mapper = new Mapper();
        configure(mapper);
        mapper.SetProperties();
        return serviceCollection;
    }
}

public class Mapper
{
    public string ProductContentType { get; set; } = string.Empty;
    public string ArticleContentType { get; set; } = string.Empty;
    public string ProductTitleParameterName { get; set; } = string.Empty;
    public string ProductContentPrameterName { get; set; } = string.Empty;
    public string ArticleDescriptionParameterName { get; set; } = string.Empty;
    public string ArticleTitleParameterName { get; set; } = string.Empty;
    public string ArticleImageUrlParamterName { get; set; } = string.Empty;

    internal void SetProperties()
    {
        MappingStorage.ProductContentType = ProductContentType;
        MappingStorage.ArticleContentType = ArticleContentType;
        MappingStorage.ProductTitleParameterName = ProductTitleParameterName;
        MappingStorage.ProductContentPrameterName = ProductContentPrameterName;
        MappingStorage.ArticleImageUrlParamterName = ArticleImageUrlParamterName;
        MappingStorage.ArticleTitleParameterName = ArticleTitleParameterName;
        MappingStorage.ArticleDescriptionParameterName = ArticleDescriptionParameterName;
    }
}

public static class MappingStorage
{
    public static string ProductContentType { get; set; } = string.Empty;
    public static string ArticleContentType { get; set; } = string.Empty;
    public static string ProductTitleParameterName { get; set; } = string.Empty;
    public static string ProductContentPrameterName { get; set; } = string.Empty;
    public static string ArticleDescriptionParameterName { get; set; } = string.Empty;
    public static string ArticleTitleParameterName { get; set; } = string.Empty;
    public static string ArticleImageUrlParamterName { get; set; } = string.Empty;
}

internal class ProductEmailWidgetContentTypeOptionsProvider : IDropDownOptionsProvider
{
    private readonly IContentQueryExecutor contentQueryExecutor;

    public ProductEmailWidgetContentTypeOptionsProvider(IContentQueryExecutor contentQueryExecutor)
        => this.contentQueryExecutor = contentQueryExecutor;

    public async Task<IEnumerable<DropDownOptionItem>> GetOptionItems()
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(MappingStorage.ProductContentType);

        var contentItems = await contentQueryExecutor.GetResult(queryBuilder, selector => new DropDownOptionItem
        {
            Value = selector.ContentItemGUID.ToString(),
            Text = selector.ContentItemName
        });

        return contentItems;
    }
}

internal class ArticleEmailWidgetContentTypeOptionsProvider : IDropDownOptionsProvider
{
    private readonly IContentQueryExecutor contentQueryExecutor;

    public ArticleEmailWidgetContentTypeOptionsProvider(IContentQueryExecutor contentQueryExecutor)
        => this.contentQueryExecutor = contentQueryExecutor;

    public async Task<IEnumerable<DropDownOptionItem>> GetOptionItems()
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(MappingStorage.ArticleContentType);

        var contentItems = await contentQueryExecutor.GetResult(queryBuilder, selector => new DropDownOptionItem
        {
            Value = selector.ContentItemGUID.ToString(),
            Text = selector.ContentItemName
        });

        return contentItems;
    }
}
