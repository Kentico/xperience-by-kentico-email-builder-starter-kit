using System.ComponentModel;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Widgets.Enums;

/// <summary>
/// The type of HTML element rendered by button widget.
/// </summary>
public enum ButtonType
{
    /// <summary>
    /// &lt;button /&gt; HTML element.
    /// </summary>
    [Description("{$$}")]
    Button,

    /// <summary>
    /// &lt;a /&gt; HTML element.
    /// </summary>
    Link
}
