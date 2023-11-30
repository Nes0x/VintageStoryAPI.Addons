namespace VintageStoryAPI.Addons.CommandHandler.Creators;

internal class InstancesCreator : IInstancesCreator
{
    public object? CreateInstance(Type type, IServiceProvider? provider)
    {
        if (provider is null) return Activator.CreateInstance(type);
        var constructors = type.GetConstructors();
        if (constructors.Length != 1) return Activator.CreateInstance(type);
        var constructor = constructors.First();
        return Activator.CreateInstance(type,
            constructor.GetParameters().Select(parameter => provider.GetService(parameter.ParameterType))
                .Where(service => service is not null).ToArray());
    }
}