namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

public interface IEmailTemplateMapper<TWidgetModel>
{
    Task<TWidgetModel> MapProperties(Guid webPageItemGuid);
    public string WebPageItemSelectorDisplayedMessage { get; set; }
}
