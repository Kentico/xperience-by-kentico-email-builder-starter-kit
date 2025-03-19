# Usage Guide

## Implement custom Web Page Item mappers.

Define a custom `WidgetDataRetriever<ArticleWidgetModel>`, which maps Web Page Items selected in the `Article` widget to display content from a page within the widget's elements.

Your custom implementation of `WidgetDataRetriever<ArticleWidgetModel>` can use dependency injection to define services and configuration required to retrieve and map the content to the `ArticleWidgetModel`.

The `ArticleWidgetModel` expects the following attributes to be set:


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

Implement the `MapProperties` method, which provides the `WebPageItemGuid` from the `WebPageSelectorComponent`. Retrieve a page content item and assign its desired properties to the `ArticleWidgetModel`. Return the model. You can map any Web Page `Content Type` to the widget.


```csharp
public class ExampleArticleWidgetEmailDataRetriever : WidgetDataRetriever<ArticleWidgetModel>
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

Similarly, implement a custom `WidgetDataRetriever<ProductWidgetModel>`, which maps `WebPageItemGuid`s to `ProductWidgetModel`s used by `Product` widgets. The `Product` widget is very similar to the `Article` widget, except it does not contain an image.

![Product widget](/images/xperience-product-widget-configuration.png)

Register these mappers as explained in the [README](../README.md).

## Define email CSS styles.

Implement your custom CSS stylesheet file with the classes expected by this library. Place the CSS file somewhere in your `wwwroot` folder and specify this path as explained in the [README](../README.md).

These styles will be automatically injected into the email widgets. However, the styles are not applied in the `Email Builder` UI. You can view the styling in the `Preview` section.
Some styles must be marked *!important* to override the default styling of the mjml library.

```css

/* The class of text contents. */
.text div,
/* The class specifying button texts. */
.button td {
	font-family: Roboto, Arial, sans-serif !important;
}

/* The classes applied to headings. */
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

/* Class applied to button element of type button. */
.button td {
	background: none !important;
}

/* Class applied to button element of type link. */
.button a {
	background: #F05A22 !important;
	border-radius: 24px !important;
	padding: 15px 32px !important;
	font-size: 14px !important;
	line-height: 16px !important;
	font-weight: 500 !important;
	font-family: inherit !important;
}

/* Class of image inside the Article and Hero widgets. */
.image img {
	border-radius: 24px;
}

/* Class for the logo widget. */
.logo {
	align-content: center;
}

.logo img {
	height: 4rem !important;
	width: 4rem !important;
}

```

![Email preview](/images/xperience-email-preview.png)

## All components

### Widgets

**Article**  
In addition to the `WidgetDataRetriever<ArticleWidgetModel>` mapper explained above, this widget allows the user to configure the following parameters:  

- **Select a web page** – The article web page item used to set the content of this widget.  
- **Content Position** – The vertical positioning of the content relative to the displayed image.  
- **Web Page Link Button Position** – Choose the vertical positioning of the button relative to the text content of this widget or set the title as a link to the original page.  
- **Go to Web Page Button Text** – The text displayed on the button that links to the original page.  

**Product**  
In addition to the `WidgetDataRetriever<ProductWidgetModel>` mapper explained above, this widget allows the user to configure the following parameters:  

- **Select a web page** – The product web page item used to set the content of this widget.  
- **Web Page Link Button Position** – Choose the vertical positioning of the button relative to the text content of this widget or set the title as a link to the original page.  
- **Go to Web Page Button Text** – The text displayed on the button that links to the original page.


**Button**  
The Button widget lets the user configure the following parameters:
- **Button text** – The text displayed in the button.
- **Button type** – Specifies whether the resulting element will be a `<button/>` or `<a/>` element.
- **URL** – The `href` parameter.
- **Alignment** – The horizontal alignment of the button.

![Button properties](/images/xperience-button-widget.png)

**Content**  
The Content widget is a simple configurable text holder. It defines the following property:
- **Content Text** – The text displayed in the element.

![Content properties](/images/xperience-content-widget.png)

**Hero**  
The Hero widget renders an image element. Available properties:
- **Image** – The Image.
- **Alt text** – The alternative text.
- **Description** – The description rendered together with the image.
- **Description position** – The vertical position of the description relative to the image.

**Logo**
The logo widget renders an image element. Available properties:
- **Logo** - The logo.

![Hero properties](/images/xperience-hero-widget.png)

### Sections

Select a section where you can add widgets.  
![Sections](/images/xperience-sections.png)

**Full Width Email Section**  
The content will be displayed inside a single full-width column.

**Two Columns Email Section**  
Two columns will be displayed in one row.

![Section usage](/images/xperience-section-usage.png)
