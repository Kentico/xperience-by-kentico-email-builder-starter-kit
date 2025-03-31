namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

/// <summary>
/// Mapper which defines methods required to map selected web page items to email builder widget models.
/// </summary>
public interface IWidgetDataRetriever<TWidgetModel>
{
    /// <summary>
    /// Based on a web page item guid maps a web page item to a <typeparamref name="TWidgetModel"/> model.
    /// </summary>
    /// <param name="webPageItemGuid">The guid of a web page item.</param>
    /// <param name="languageName">Language of the current email channel.</param>
    /// <returns>The <typeparamref name="TWidgetModel"/> of a widget.</returns>
    public Task<TWidgetModel> MapProperties(Guid webPageItemGuid, string languageName);
}
