namespace VintageStoryAPI.Addons.CommandHandler.Creators;

internal class InstancesCreator : IInstancesCreator
{
    private readonly IServiceProvider? _provider;

    public InstancesCreator(IServiceProvider? provider = null)
    {
        _provider = provider;
    }

    public object? CreateInstance(Type type)
    {
        if (_provider is null) return Activator.CreateInstance(type);
        var constructors = type.GetConstructors();
        if (constructors.Length != 1) return Activator.CreateInstance(type);
        var constructor = constructors.First();
        return Activator.CreateInstance(type,
            constructor.GetParameters().Select(parameter => _provider.GetService(parameter.ParameterType))
                .Where(service => service is not null).ToArray());
    }
}