using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.CommandHandler.Factories;

internal class InstanceFactory
{
    private readonly IInstanceCreator _instanceCreator;
    private readonly IServiceProvider? _provider;

    public InstanceFactory(IInstanceCreator instanceCreator, IServiceProvider? provider = null)
    {
        _instanceCreator = instanceCreator;
        _provider = provider;
    }


    public TInstance Create<TInstance>(Type commandType, TextCommandCallingArgs context)
        where TInstance : class, IContext
    {
        var instance = (TInstance)_instanceCreator.Create(commandType, _provider)!;
        instance.Context = context;
        return instance;
    }
}