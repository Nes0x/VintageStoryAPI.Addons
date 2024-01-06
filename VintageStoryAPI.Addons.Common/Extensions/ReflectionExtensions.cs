using System.Reflection;

namespace VintageStoryAPI.Addons.Common.Extensions;

public static class ReflectionExtensions
{
    public static IEnumerable<object?> ReadProperties<T>(this Attribute attribute) where T : Attribute
    {
        return attribute.GetType().GetProperties()
            .Where(property => property.GetCustomAttribute<T>() is not null)
            .Select(property => property.GetValue(attribute));
    }

    public static IEnumerable<Type> GetAllTypes<T>(this Assembly assembly)
    {
        return assembly.GetTypes().Where(type =>
            type.IsAssignableTo(typeof(T)) && !type.IsAbstract);
    }

    public static IEnumerable<MethodInfo> GetSpecificMethods(this IEnumerable<Type> types,
        Func<MethodInfo, bool> condition)
    {
        return types.SelectMany(type =>
            type.GetMethods()
                .Where(condition.Invoke));
    }

    public static IEnumerable<MethodInfo> GetSpecificMethods(this Type types, Func<MethodInfo, bool> condition)
    {
        return types.GetMethods().Where(condition.Invoke);
    }

    public static IEnumerable<MethodInfo> GetSpecificMethods<T>(this Assembly assembly,
        Func<MethodInfo, bool> condition)
    {
        return GetAllTypes<T>(assembly).SelectMany(type =>
            type.GetMethods()
                .Where(condition.Invoke));
    }
}