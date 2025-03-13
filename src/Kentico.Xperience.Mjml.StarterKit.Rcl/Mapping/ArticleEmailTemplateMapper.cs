using Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

/// <summary>
/// Mapper of <see cref="ArticleWidgetModel"/> for <see cref="ArticleWidget"/>
/// </summary>
public interface IArticleEmailTemplateMapper : IEmailTemplateMapper<ArticleWidgetModel>
{ }

/// <inheritdoc />
public abstract class ArticleEmailTemplateMapper : IArticleEmailTemplateMapper
{
    /// <summary>
    /// Based on a web page item guid maps a web page item to <see cref="ArticleWidgetModel"/> model.
    /// </summary>
    /// <param name="webPageItemGuid">The guid of a web page item.</param>
    /// <returns>The <see cref="ArticleWidgetModel"/>.</returns>
    public virtual Task<ArticleWidgetModel> MapProperties(Guid webPageItemGuid) => Task.FromResult(new ArticleWidgetModel());
}
