using System.Reflection;

namespace VintageStoryAPI.Addons.Common.Creators;

public class InstanceCreator : IInstanceCreator
{
    public object? Create(Type type, IServiceProvider? provider)
    {
        if (provider is null) return CreateParameterless(type);
        var constructors = type.GetConstructors();
        if (constructors.Length != 1)
            throw new ArgumentException("You can create only one constructor to use with dependency injection.");
        var constructor = constructors.First();
        var services = constructor
            .GetParameters()
            .Select(parameter => provider.GetService(parameter.ParameterType))
            .Where(service => service is not null)
            .ToArray();
        if (services.Length != constructor.GetParameters().Length)
            throw new TargetParameterCountException("Constructor parameters length don't match services length from provider.");
        return Activator.CreateInstance(type, services);
    }
    
    private object? CreateParameterless(Type type)
    {
        var constructor = type.GetConstructor(Type.EmptyTypes);
        if (constructor is null)
            throw new ArgumentException("Can't create instance without parameterless constructor.");
        return Activator.CreateInstance(type);
    }
}