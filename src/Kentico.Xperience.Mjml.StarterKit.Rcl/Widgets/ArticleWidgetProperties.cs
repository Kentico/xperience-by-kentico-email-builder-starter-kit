using CMS.Websites;

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
        Options = $"{nameof(DescriptionPositionOption.Above)};{nameof(DescriptionPositionOption.Above)}\r\n{nameof(DescriptionPositionOption.Below)};{nameof(DescriptionPositionOption.Below)}",
        OptionsValueSeparator = ";")]
    public string DescriptionPosition { get; set; } = "";

    [WebPageSelectorComponent(Label = "Select a web page.", MaximumPages = 1)]
    public IEnumerable<WebPageRelatedItem> Pages { get; set; } = [];
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
