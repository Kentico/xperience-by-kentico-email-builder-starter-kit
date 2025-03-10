using Microsoft.AspNetCore.Components;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Sections;

public partial class EmailSectionBase : ComponentBase
{
    [Parameter]
    public int NumberOfSections { get; set; }
}
