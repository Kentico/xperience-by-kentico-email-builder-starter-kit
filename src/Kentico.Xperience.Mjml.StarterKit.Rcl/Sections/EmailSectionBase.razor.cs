using Microsoft.AspNetCore.Components;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

/// <summary>
/// Defines a base for an Email section.
/// </summary>
public partial class EmailSectionBase : ComponentBase
{
    /// <summary>
    /// The number of columns in a section.
    /// </summary>
    [Parameter]
    public int NumberOfSectionColumns { get; set; }
}
