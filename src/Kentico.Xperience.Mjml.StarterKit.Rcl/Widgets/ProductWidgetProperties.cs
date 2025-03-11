using CMS.Websites;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Admin.Websites.FormAnnotations;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets;

public class ProductWidgetProperties : IEmailWidgetProperties
{
    [WebPageSelectorComponent(Label = "Select a web page.", MaximumPages = 1)]
    public IEnumerable<WebPageRelatedItem> Pages { get; set; } = [];
}
