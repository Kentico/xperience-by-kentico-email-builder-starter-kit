using CMS.DataEngine;

namespace Kentico.Xperience.Mjml.StarterKit.Rcl.Helpers;

internal static class DataClassInfoProviderHelper
{
    /// <summary>
    /// Get class guids by code names
    /// </summary>
    /// <param name="codeNames"></param>
    /// <returns></returns>
    public static IEnumerable<Guid> GetClassGuidsByCodeNames(IEnumerable<string> codeNames)
    {
        var enumerable = codeNames as string[] ?? codeNames.ToArray();
        
        if (enumerable.Length == 0)
        {
            return new List<Guid>();
        }

        var classes = DataClassInfoProvider
            .GetClasses()
            .WhereEquals(nameof(DataClassInfo.ClassType), ClassType.CONTENT_TYPE)
            .WhereIn(nameof(DataClassInfo.ClassShortName), enumerable)
            .Columns(DataClassInfo.TYPEINFO.GUIDColumn, DataClassInfo.TYPEINFO.CodeNameColumn)
            .ToList();

        return classes.Select(i => i.ClassGUID).Distinct();
    }
}
