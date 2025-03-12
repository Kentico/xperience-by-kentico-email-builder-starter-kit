using CMS.Websites;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public class ProductWidgetProperties : IEmailWidgetProperties
{
    [WebPageSelectorComponent(Label = "Select a web page.", MaximumPages = 1)]
    public IEnumerable<WebPageRelatedItem> Pages { get; set; } = [];
}

public interface IEmailTemplateMapper<TWidgetModel>
{
    Task<TWidgetModel> MapProperties(Guid webPageItemGuid);
    public string WebPageItemSelectorDisplayedMessage { get; set; }
}

public interface IProductEmailTemplateMapper : IEmailTemplateMapper<ProductWidgetModel>
{ }

public interface IArticleEmailTemplateMapper : IEmailTemplateMapper<ArticleWidgetModel>
{ }

public abstract class ProductEmailTemplateMapper : IProductEmailTemplateMapper
{
    public virtual string WebPageItemSelectorDisplayedMessage { get; set; } = string.Empty;
    public virtual Task<ProductWidgetModel> MapProperties(Guid webPageItemGuid) => Task.FromResult(new ProductWidgetModel());
}

public abstract class ArticleEmailTemplateMapper : IArticleEmailTemplateMapper
{
    public virtual string WebPageItemSelectorDisplayedMessage { get; set; } = string.Empty;
    public virtual Task<ArticleWidgetModel> MapProperties(Guid webPageItemGuid) => Task.FromResult(new ArticleWidgetModel());
}

public class ProductWidgetModel
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}

public class ArticleWidgetModel
{
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
}
