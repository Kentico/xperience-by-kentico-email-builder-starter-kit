# Usage Guide

- [Starter Kit component reference](#starter-kit-component-reference)
- [Implement Image and Product model mappers](#implement-image-and-product-model-mappers)
- [Implement email data mapping](#implement-email-data-mapping)
    - [Single email content type](#single-email-content-type)
    - [Multiple email content types](#multiple-email-content-types)
- [Define email CSS styles](#define-email-css-styles)

## Starter Kit component reference

### Widgets

**Button**

Displays a button that opens a specified URL when clicked. Uses the [\<mj-button\>](https://documentation.mjml.io/#mj-button) tag, or a standard `<a>` tag within [\<mj-text\>](https://documentation.mjml.io/#mj-text).

Users can configure the following properties:

- **Button text** – the text displayed in the button.
- **URL** – the URL opened when the button is selected. Allowed URL formats: absolute (starting with a protocol), relative (starting with /), or virtual (starting with ~).
- **Button type** – specifies whether the widget renders a `<button>` or `<a>` tag.
- **Alignment** – the horizontal alignment of the button.

**Divider**

Displays a horizontal divider that can be customized like a HTML border. Uses the [\<mj-divider\>](https://documentation.mjml.io/#mj-divider) tag.

Users can configure the following properties:

- **Border width** – the border sizeof the divider in pixels.
- **Border color** – the [HTML color](https://www.w3schools.com/html/html_colors.asp) of the divider, either as a color name or hex code (e.g., 'blue' or '#fed').
- **Border style** – the [border style](https://www.w3schools.com/cssref/pr_border-style.php) (e.g., 'solid', 'dotted', 'dashed', 'dotted double').

**Image**

Displays an image, which can be selected from images stored as [content item assets](https://docs.kentico.com/x/content_item_assets_xp) in Content hub. Uses the [\<mj-image\>](https://documentation.mjml.io/#mj-image) tag.

Users can configure the following properties:

- **Image** – selector for the image's content item asset.
- **Alignment** – the horizontal alignment of the image.
- **Width** – the width of the image in pixels. Limited by the width allowed by the section containing the widget.

**Requirements**: To use the *Image* widget, you need to:

- Specify the code names of [content types](https://docs.kentico.com/x/gYHWCQ) representing image assets in your project via the `AllowedImageContentTypes` Starter Kit option (see [Email Builder and Starter Kit setup](../README.md#email-builder-and-starter-kit-setup)).
- Implement and register an [image model mapper](#implement-image-and-product-model-mappers) (`IComponentModelMapper<ImageWidgetModel>`), which populates `ImageWidgetModel` properties based on the selected content item asset.

**Product**

Displays product content based on a selected website channel page. Consists of an image, title, text and a link button that opens the product page. See [Model the product catalog](https://docs.kentico.com/x/commerce_catalog_xp) to learn how you can store products as pages in Xperience by Kentico.

Users can configure the following properties:

- **Product page** – the product page representing the displayed product.
- **Product page button text** – the text displayed as the caption of the button that links to the product page.

**Requirements**: To use the *Product* widget, you need to:

- Specify the code names of [content types](https://docs.kentico.com/x/gYHWCQ) representing product pages in your project via the `AllowedProductContentTypes` Starter Kit option (see [Email Builder and Starter Kit setup](../README.md#email-builder-and-starter-kit-setup)).
- Implement and register a [product model mapper](#implement-image-and-product-model-mappers) (`IComponentModelMapper<ProductWidgetModel>`), which populates `ProductWidgetModel` properties based on the selected product page.

**Text**

Allows users to add and format text content. Content is added directly in the Email Builder interface via the Xperience [Rich text inline editor](https://docs.kentico.com/developers-and-admins/development/builders/email-builder/inline-editors-email-builder-widgets#rich-text-inline-editor).

### Sections

Email Builder [sections](https://docs.kentico.com/developers-and-admins/development/builders/email-builder/develop-email-builder-components#sections) specify the layout for email content, with zones where you can add widgets. The Starter Kit includes the following sections:

- **Full-width section** – content is displayed inside a single full-width column.
- **Two-column section** – provides two columns side-by-side for content.

![Section usage](/images/xperience-section-usage.png)

## Implement image and product model mappers

Every Xperience project may use its own specific [content types](https://docs.kentico.com/x/gYHWCQ) to represent images and product pages. To use the **Image** and **Product** widgets, you need to implement and register model mappers that convert data from your project's content types into the `<ImageWidgetModel>` and `<ProductWidgetModel>` models, which the widgets use to display content.

### Image model mapper

Create a class in your Xperience project that implements `IComponentModelMapper<ImageWidgetModel>` and define its `Map` method. Call the [Content item query API](https://docs.kentico.com/x/WhT_Cw) to retrieve the selected content item asset with image data. Use the data to populate and return an `ImageWidgetModel` instance.

For example:

```csharp
public class ExampleImageWidgetModelMapper(IContentQueryExecutor executor) : IComponentModelMapper<ImageWidgetModel>
{
    public async Task<ImageWidgetModel> Map(Guid itemGuid, string languageName)
    {
        // Retrieves the selected content item asset
        var query = new ContentItemQueryBuilder()
            .ForContentType(Image.CONTENT_TYPE_NAME,
                config => config
                    .Where(where => where.WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), itemGuid))
                    .TopN(1))
            .InLanguage(languageName);
        
        var result = await executor.GetMappedResult<Image>(query);

        var item = result?.FirstOrDefault();

        if (item is null)
        {
            return new ImageWidgetModel();
        }

        return new ImageWidgetModel()
        {
            // Populates the image URL and alt text from the retrieved content item's fields
            ImageUrl = item.ImageFile?.Url,
            AltText = item.ImageShortDescription
        };
    }
}
```

Register the model mapper in your Xperience project's `Program.cs` file:

```csharp
// Registers the image model mapper
builder.Services.AddScoped<IComponentModelMapper<ImageWidgetModel>, ExampleImageWidgetModelMapper>();
```

### Product model mapper

Create a class in your Xperience project that implements `IComponentModelMapper<ProductWidgetModel>` and define its `Map` method. Call the [Content item query API](https://docs.kentico.com/x/WhT_Cw) to retrieve the selected page with product data. Use the data to populate and return an `ProductWidgetModel` instance.

For example:

```csharp

public class ExampleProductWidgetModelMapper(IContentQueryExecutor executor, IWebPageUrlRetriever webPageUrlRetriever)
    : IComponentModelMapper<ProductWidgetModel>
{
    public async Task<ProductWidgetModel> Map(Guid itemGuid, string languageName)
    {
        // Retrieves the selected product page with a linked product content item
        var query = new ContentItemQueryBuilder()
            .ForContentTypes()
            .ForContentType(ProductPage.CONTENT_TYPE_NAME,
                config => config
                    .WithLinkedItems(10)
                    .ForWebsite(DancingGoatConstants.WEBSITE_CHANNEL_NAME, includeUrlPath: true)
                    .Where(where => where
                        .WhereEquals(nameof(IContentQueryDataContainer.ContentItemGUID), itemGuid)))
            .InLanguage(languageName);

        var result = await executor.GetMappedResult<ProductPage>(query);
        
        var productPage = result.FirstOrDefault();

        if (productPage is null)
        {
            return new ProductWidgetModel();
        }

        // Gets the product page URL
        var webPageItemUrl = await webPageUrlRetriever.Retrieve(productPage.SystemFields.WebPageItemID, languageName);

        // Gets product data stored in fields of the 'Product fields' reusable field schema
        var product = productPage.ProductPageProduct?.FirstOrDefault() as IProductFields;
        
        if (product is null)
        {
            return new ProductWidgetModel();
        }
        
        var image = product.ProductFieldImage.FirstOrDefault();

        return new ProductWidgetModel
        {
            // Populates the product widget content using the retrieved data
            Name = product.ProductFieldName,
            Description = product.ProductFieldDescription,
            Url = webPageItemUrl.AbsoluteUrl,
            ImageUrl = image?.ImageFile.Url,
            ImageAltText = image != null ? image.ImageShortDescription : string.Empty
        };
    }
}

```

Register the model mapper in your Xperience project's `Program.cs` file:

```csharp
// Registers the product model mapper
builder.Services.AddScoped<IComponentModelMapper<ProductWidgetModel>, ExampleProductWidgetModelMapper>();
```

## Implement email data mapping

Every Xperience project may use different [content types](https://docs.kentico.com/x/gYHWCQ) to represent email content. To use the default **Email Builder Starter Kit Template**, you need to implement and register an email data mapper that converts data from your project's email content types into the `IEmailData` contract, which the template uses to populate the email's subject and preview text.

You can use a similar approach if you wish to access email data within your own Email Builder components. If you wish to access data from other fields within your custom email content types, extend `IEmailData` and `EmailData` in `src\Kentico.Xperience.Mjml.StarterKit.Rcl\Contracts`.

The Email Builder Starter Kit supports two email data mapping scenarios:

1. **Single email content type** – when your project uses only one content type for emails
2. **Multiple email content types** – when your project uses multiple different content types for different types of emails

### Single email content type

Create a class in your Xperience project that implements `IEmailDataMapper` and define the `Map` method. Use the [EmailContext](https://docs.kentico.com/documentation/developers-and-admins/development/builders/email-builder/develop-email-builder-components#email-fields) API to retrieve the value of the `EmailSubject` and `EmailPreviewText` fields, using the model class [generated](https://docs.kentico.com/x/5IbWCQ) for your email content type.

```csharp
/// <summary>
/// Simple email data mapper for projects with a single email content type.
/// </summary>
public class SimpleEmailDataMapper : IEmailDataMapper
{
    private readonly IEmailContextAccessor emailContextAccessor;

    public SimpleEmailDataMapper(IEmailContextAccessor emailContextAccessor)
    {
        this.emailContextAccessor = emailContextAccessor;
    }

    public async Task<IEmailData> Map()
    {
        var emailContext = emailContextAccessor.GetContext();
        
        // Gets a strongly-typed representation of your project's email content type
        // Replace 'BuilderEmail' with the generated model class for your email content type
        var email = await emailContext.GetEmail<BuilderEmail>();

        // Maps the email data to the IEmailData contract
        return new EmailData(email?.EmailSubject, email?.EmailPreviewText);
    }
}
```

Register the email data mapper in your Xperience project's `Program.cs` file:

```csharp
// Registers the email data mapper for a single content type
builder.Services.AddScoped<IEmailDataMapper, SimpleEmailDataMapper>();
```

### Multiple email content types

If your project uses multiple content types for different types of emails (e.g., newsletters, promotional emails, order notifications), you need to implement a mapper that can handle all these types dynamically.

Create a class in your Xperience project that implements `IEmailDataMapper` and define the `Map` method. Use the [EmailContext](https://docs.kentico.com/documentation/developers-and-admins/development/builders/email-builder/develop-email-builder-components#email-fields) API to retrieve the value of the `EmailSubject` and `EmailPreviewText` fields, using the model classes [generated](https://docs.kentico.com/x/5IbWCQ) for your email content types.

```csharp
/// <summary>
/// Email data mapper for projects with multiple email content types.
/// Dynamically determines the content type and maps accordingly.
/// </summary>
public class MultiTypeEmailDataMapper : IEmailDataMapper
{
    private readonly IEmailContextAccessor emailContextAccessor;
    
    public MultiTypeEmailDataMapper(IEmailContextAccessor emailContextAccessor)
    {
        this.emailContextAccessor = emailContextAccessor;
    }

    public async Task<IEmailData> Map()
    {
        var emailContext = emailContextAccessor.GetContext();
        
        // Determines the content type and performs mapping accordingly
        return emailContext.ContentTypeName switch
        {
            // Newsletter email content type
            NewsletterEmail.CONTENT_TYPE_NAME => await MapNewsletterEmail(emailContext),
            
            // Promotional email content type
            PromotionalEmail.CONTENT_TYPE_NAME => await MapPromotionalEmail(emailContext),
            
            // General builder email content type (fallback)
            BuilderEmail.CONTENT_TYPE_NAME => await MapBuilderEmail(emailContext),
            
            // Default fallback for unknown content types
            _ => new EmailData("Unknown Email Type", "This email type is not configured.")
        };
    }
    
    private async Task<IEmailData> MapNewsletterEmail(EmailContext emailContext)
    {
        // Gets a strongly-typed representation of your project's newsletter email content type
        var email = await emailContext.GetEmail<NewsletterEmail>();
        
        if (email is null)
        {
            return new EmailData("Newsletter", "Newsletter content not found.");
        }

        // Maps the preview text with newsletter-specific default values
        var previewText = !string.IsNullOrEmpty(email.EmailPreviewText) 
            ? email.EmailPreviewText
            // Uses a value from a 'NewsletterDate' field in the newsletter content type
            : $"Newsletter from {email.NewsletterDate:MMMM yyyy}";

        return new EmailData(email.EmailSubject, previewText);
    }
    
    private async Task<IEmailData> MapPromotionalEmail(EmailContext emailContext)
    {
        // Gets a strongly-typed representation of your project's promotional email content type
        var email = await emailContext.GetEmail<PromotionalEmail>();
        
        if (email is null)
        {
            return new EmailData("Promotion", "Promotional content not found.");
        }

        // Maps the preview text with promotional email-specific default values
        var previewText = !string.IsNullOrEmpty(email.EmailPreviewText)
            ? email.EmailPreviewText
            // Uses a value from a 'PromotionalDiscountPercentage' field in the promotional email content type
            : $"Special offer: {email.PromotionalDiscountPercentage}% OFF";

        return new EmailData(email.EmailSubject, previewText);
    }
    
    private async Task<IEmailData> MapBuilderEmail(EmailContext emailContext)
    {
        // Gets a strongly-typed representation of your project's general builder email content type
        var email = await emailContext.GetEmail<BuilderEmail>();
        
        if (email is null)
        {
            return new EmailData("Builder Email", "Builder email content not found.");
        }

        var email = await emailContext.GetEmail<BuilderEmail>();

        // Maps the email data to the IEmailData contract
        return new EmailData(email.EmailSubject, email.EmailPreviewText);
    }
}
```

Register the email data mapper in your Xperience project's `Program.cs` file:

```csharp
// Registers the email data mapper for multiple content types
builder.Services.AddScoped<IEmailDataMapper, MultiTypeEmailDataMapper>();
```

## Define email CSS styles

Implement your custom CSS stylesheet file with the classes expected by the Starter Kit components. Place the CSS file in your project's `wwwroot` folder and specify this path in the `StyleSheetPath` Starter Kit option as explained in [Email Builder and Starter Kit setup](../README.md#email-builder-and-starter-kit-setup).

These styles will be automatically injected into Email Builder components. Some styles must be marked *!important* to override the default styling of the MJML library.

**Limitation**: In current versions of Xperience by Kentico, the styles are not applied in the **Email Builder** UI. You can view the styling in the `Preview` mode or when sending test emails.

```css

/* Class of text content */
.mj-email-text div,
    /* Class specifying button texts */
.mj-email-button td {
    font-family: Roboto, Arial, sans-serif !important;
}

/* Classes applied to headings */
.mj-email-text h1,
.mj-email-text h2,
.mj-email-text h3 {
    line-height: 1.5 !important;
    font-family: inherit !important;
}

.mj-email-text h1 {
    font-size: 24px !important;
}

.mj-email- h2 {
    font-size: 20px !important;
}

.mj-email-text h3 {
    font-size: 16px !important;
}

.mj-email-text p {
    line-height: 1.5 !important;
    font-size: 14px !important;
    font-family: Roboto, Arial, sans-serif !important;
}

.mj-email-text p a {
    text-decoration: underline;
    color: #F05A22;
}

/* Class applied to Button widget elements of type button */
.mj-email-button td {
    background: none !important;
}

/* Class applied to Button widget elements of type link */
.mj-email-button a {
    background: #F05A22 !important;
    border-radius: 24px !important;
    padding: 15px 32px !important;
    font-size: 14px !important;
    line-height: 16px !important;
    font-weight: 500 !important;
    font-family: inherit !important;
}

/* Classes applied to the Image widget and images in the Product widget */
.mj-email-image img {
    border-radius: 24px;
}

.mj-email-logo {
    align-content: center;
}

.mj-email-logo img {
    height: 4rem !important;
    width: 4rem !important;
}


/* Classes applied to the Product widget */
.email-product_title h1 {
    font-size: 24px !important;
    color: #F05A22;
    font-family: Roboto, Arial, sans-serif !important;
}

.email-product_description p {
    font-family: Roboto, Arial, sans-serif !important;
    line-height: 1.5 !important;
}

.email-product_button td {
    background: #fff !important;
}

.email-product_button a {
    background: #F05A22 !important;
    border-radius: 24px !important;
    padding: 15px 32px !important;
    font-size: 14px !important;
    line-height: 16px !important;
    font-weight: 500 !important;
    font-family: Roboto, Arial, sans-serif !important;
}

```

![Email preview](/images/xperience-email-preview.png)