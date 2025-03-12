using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

public interface IArticleEmailTemplateMapper : IEmailTemplateMapper<ArticleWidgetModel>
{ }

public abstract class ArticleEmailTemplateMapper : IArticleEmailTemplateMapper
{
    public virtual string WebPageItemSelectorDisplayedMessage { get; set; } = string.Empty;
    public virtual Task<ArticleWidgetModel> MapProperties(Guid webPageItemGuid) => Task.FromResult(new ArticleWidgetModel());
}
