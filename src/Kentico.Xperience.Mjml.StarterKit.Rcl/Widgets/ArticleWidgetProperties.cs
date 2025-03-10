using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Base.FormAnnotations;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public class ArticleWidgetProperties : IEmailWidgetProperties
{
    /// <summary>
    /// 
    /// </summary>
    [DropDownComponent(
        Label = "Description Position",
        Order = 4,
        ExplanationText = "Select where to display the description",
        Options = $"{nameof(DescriptionPositionOption.Above)};{nameof(DescriptionPositionOption.Below)}",
        OptionsValueSeparator = ";")]
    public string DescriptionPosition { get; set; } = "";

    /// <summary>
    /// 
    /// </summary>
    [DropDownComponent(Label = "Content item", DataProviderType = typeof(ArticleEmailWidgetContentTypeOptionsProvider))]
    [WebPageSelectorComponent(Label = "Web page")]
    public string ContentItemGuid { get; set; } = string.Empty;
}

/// <summary>
/// 
/// </summary>
public enum DescriptionPositionOption
{
    /// <summary>
    /// 
    /// </summary>
    Above,
    /// <summary>
    /// 
    /// </summary>
    Below
}
