using System.Reflection;

namespace VintageStoryAPI.Addons.Common.Creators;

public class InstancesCreator : IInstancesCreator
{
    public object? CreateInstance(Type type)
    {
        var constructor = type.GetConstructor(Type.EmptyTypes);
        if (constructor is null) throw new ArgumentException("Cannot create instance without parameterless constructor");
        return Activator.CreateInstance(type);
    }

    public object? CreateInstance(Type type, IServiceProvider? provider)
    {
        if (provider is null) return CreateInstance(type);
        var constructors = type.GetConstructors();
        if (constructors.Length != 1) throw new ArgumentException("You can create only one constructor to use with dependency injection.");
        var constructor = constructors.First();
        var services = constructor.GetParameters().Select(parameter => provider.GetService(parameter.ParameterType))
            .Where(service => service is not null).ToArray();
        if (services.Length != constructor.GetParameters().Length) throw new TargetParameterCountException("Constructor parameters don't match services from provider.");
        return Activator.CreateInstance(type, services);
    }
}