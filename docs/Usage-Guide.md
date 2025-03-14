# Usage Guide

## Implement custom Web Page Item mappers.

Define a custom `ArticleEmailTemplateMapper`. This class will be used to map Web Page Items selected in `Article` widget to display the content from a page in the `Article` widget elements.

Your custom implementation of `ArticleEmailTemplateMapper` can use dependency injection to define services and configuration used to retrieve and map the content to the `ArticleWidgetModel`.

The article widget model expects the following attributes to be set.

```csharp
public class ArticleWidgetModel
{
    /// <summary>
    /// The title of the widget.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// The text content of the widget.
    /// </summary>
    public string Content { get; set; } = string.Empty;

    /// <summary>
    /// The url of an image displayed in the widget.
    /// </summary>
    public string ImageUrl { get; set; } = string.Empty;
}
```

Implement the `MapProperties` method which provides the `WebPageItemGuid` from the `WebPageSelectorComponent`. Retrieve a page content item and assign it's desired properties to the `ArticleWidgetModel`. Return the model. You can map any Web Page `Content Type` to the widget.

```csharp
public class ExampleArticleEmailTemplateMapper : ArticleEmailTemplateMapper
{
    private readonly IContentQueryExecutor contentQueryExecutor;
    private readonly IWebPageQueryResultMapper webPageMapper;

    public const string WEBSITE_CHANNEL_NAME = "DancingGoatPages";
    public const string WEBSITE_LANGUAGE_NAME = "en";

    public ExampleArticleEmailTemplateMapper(IContentQueryExecutor contentQueryExecutor,
        IWebPageQueryResultMapper webPageMapper)
    {
        this.contentQueryExecutor = contentQueryExecutor;
        this.webPageMapper = webPageMapper;
    }

    public override async Task<ArticleWidgetModel> MapProperties(Guid webPageItemGuid)
    {
        var queryBuilder = new ContentItemQueryBuilder()
            .ForContentType(ArticlePage.CONTENT_TYPE_NAME,
                config => config.WithLinkedItems(10)

                // Because the webPageItemGuid is a reusable content item, we don't have a website channel name to use here
                // so we use a hardcoded channel name.

                .ForWebsite(WEBSITE_CHANNEL_NAME)
                .Where(
                    x => x.WhereEquals(nameof(WebPageFields.WebPageItemGUID), webPageItemGuid)
                )
            )

            // Because the changedItem is a reusable content item, we don't have a language name to use here
            // so we use a hardcoded channel name.

            .InLanguage(WEBSITE_LANGUAGE_NAME);

        var result = await contentQueryExecutor.GetWebPageResult(queryBuilder, webPageMapper.Map<ArticlePage>);
        var articlePage = result.FirstOrDefault();

        if (articlePage is null)
        {
            return new();
        }

        return new ArticleWidgetModel
        {
            Title = articlePage.ArticleTitle,
            Content = articlePage.ArticlePageSummary,
            ImageUrl = articlePage.ArticlePageTeaser.FirstOrDefault()?.ImageFile.Url ?? string.Empty
        };
    }
}

```

![Article widget](/images/xperience-article-widget-configuration.png)

Similiarly implement a custom `ProductEmailTemplateMapper` which maps `WebPageItemGuid`s to `ProductWidgetModel`s which are used by `Product` widgets. The `Product` widget is very similiar to the `Article` widget, except it does not contain an image.

![Product widget](/images/xperience-product-widget-configuration.png)

Register these mappers as explained in the [README](../README.md).

## Define email css styles.
Implement your custom css style sheet file with the classes expected by this library. Place the css file somewhere in your `wwwroot` folder and specify this path as explained in the [README](../README.md).

These styles will be automaticaly injected into the email widgets. The styles however are not applied in the `Email Builder` UI. You can view the styling in the `Preview` section.

```css
.text div,
.button td {
	font-family: Roboto, Arial, sans-serif !important;
}

.text h1,
.text h2,
.text h3 {
	line-height: 1.5 !important;
	font-family: inherit !important;
}

.text h1 {
	font-size: 24px !important;
}

.text h2 {
	font-size: 20px !important;
}

.text h3 {
	font-size: 16px !important;
}

.text p {
	line-height: 1.5 !important;
	font-size: 14px !important;
	font-family: Roboto, Arial, sans-serif !important;
}

	.text p a {
		text-decoration: underline;
		color: #F05A22;
	}

.button td {
	background: none !important;
}

.button a {
	background: #F05A22 !important;
	border-radius: 24px !important;
	padding: 15px 32px !important;
	font-size: 14px !important;
	line-height: 16px !important;
	font-weight: 500 !important;
	font-family: inherit !important;
}

.image img {
	border-radius: 24px;
}

```

![Email preview](/images/xperience-email-preview.png)

## All components
### Widgets
*Product*
- (explained above)

*Article*
- (explained above)

*Button*
The Button widget lets the user configure the following parameters:
- Button text - the text displayed in the button.
- Button type - whether the resulting element will be the `<button/>` or `<a/>` element.
- URL - the `href` parameter.
- Alignment - the horizontal aligment of the button.
![Button properties](/images/xperience-button-widget.png)

*Content*
The Content widget is a simple configurable text holder. It defines the property:
- Content Text - the text displayed in the element.
![Content properties](/images/xperience-content-widget.png)

*Hero*
The Hero widget renders a an image element. Available properties:
- Image URL - the url of the image.
- Alt text - the alt text.
- Description - the description rendered together with the image.
- Description position - the vertical position of the description relative to the image.
![Hero properties](/images/xperience-hero-widget.png)

### Sections
Select a section where you can add widgets.
![Sections](/images/xperience-sections.png)

*Full Width Email Section*
The content will be displayed inside a single full width column.

*Two Columns Email Section*
Two column will be displayed in one row.

![Section usage](/images/xperience-section-usage.png)