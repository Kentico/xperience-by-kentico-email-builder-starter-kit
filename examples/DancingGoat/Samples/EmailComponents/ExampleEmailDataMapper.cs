using DancingGoat.Models;

using Kentico.EmailBuilder.Web.Mvc;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Contracts;
using Kentico.Xperience.Mjml.StarterKit.Rcl.Mapping;

namespace DancingGoat.Samples.EmailComponents;

/// <summary>
/// Example implementation of email data mapper for DancingGoat emails.
/// Maps strongly-typed email content to the email data contract using <see cref="EmailContext.GetEmail{T}(CancellationToken)"/>.
/// </summary>
public class ExampleEmailDataMapper : IEmailDataMapper
{
    private readonly IEmailContextAccessor emailContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExampleEmailDataMapper"/> class.
    /// </summary>
    /// <param name="emailContextAccessor">The email context accessor service.</param>
    public ExampleEmailDataMapper(IEmailContextAccessor emailContextAccessor)
    {
        this.emailContextAccessor = emailContextAccessor;
    }

    /// <inheritdoc />
    public async Task<IEmailData> Map()
    {
        var emailContext = emailContextAccessor.GetContext();
        var email = await emailContext.GetEmail<BuilderEmail>();

        return new EmailData(email?.EmailSubject, email?.EmailPreviewText);
    }
}
