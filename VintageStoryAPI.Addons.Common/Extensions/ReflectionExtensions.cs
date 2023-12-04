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

    public static IEnumerable<Type> GetAllTypesFromAssemblyByGeneric<T>(this Assembly assembly)
    {
        return assembly.GetTypes().Where(type =>
            type.IsAssignableTo(typeof(T)) && !type.IsAbstract);
    }

    public static IEnumerable<MethodInfo> GetSpecificMethodsFromTypes(this IEnumerable<Type> types, Func<MethodInfo, bool> condition)
    {
        return types.SelectMany(type =>
            type.GetMethods()
                .Where(condition.Invoke));
    }
    
    public static IEnumerable<MethodInfo> GetSpecificMethodsFromType(this Type types, Func<MethodInfo, bool> condition)
    {
        return types.GetMethods().Where(condition.Invoke);
    }
    
    public static IEnumerable<MethodInfo> GetSpecificMethodsFromTypes<T>(this Assembly assembly, Func<MethodInfo, bool> condition)
    {
        return GetAllTypesFromAssemblyByGeneric<T>(assembly).SelectMany(type =>
            type.GetMethods()
                .Where(condition.Invoke));
    }
    
}