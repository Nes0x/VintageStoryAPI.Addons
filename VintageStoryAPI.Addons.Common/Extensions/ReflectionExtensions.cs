using System.Reflection;

namespace VintageStoryAPI.Addons.Common.Extensions;

public static class ReflectionExtensions
{
    public static IEnumerable<object?> ReadPropertiesByAttribute<T>(this Attribute attribute) where T : Attribute
    {
        return attribute.GetType().GetProperties()
            .Where(property => property.GetCustomAttribute<T>() is not null)
            .Select(property => property.GetValue(attribute));
    }
}