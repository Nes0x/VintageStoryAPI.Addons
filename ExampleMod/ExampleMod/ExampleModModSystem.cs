using ExampleMod.Creators;
using Microsoft.Extensions.DependencyInjection;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler;
using VintageStoryAPI.Addons.CommandHandler.Common;

namespace ExampleMod;

public class ExampleModModSystem : ModSystem
{
    private IServiceCollection _collection;
    private ICoreAPI _coreApi;
    
    public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Client;

    public override void StartClientSide(ICoreClientAPI api)
    {
        var commandHandler = new CommandHandler<ICoreClientAPI>(api, _coreApi, _collection.BuildServiceProvider());
        commandHandler.RegisterCommands();
    }

    public override void StartPre(ICoreAPI api)
    {
        _coreApi = api;
        _collection = new ServiceCollection();
        _collection.AddSingleton<MessageCreator>();
    }
}