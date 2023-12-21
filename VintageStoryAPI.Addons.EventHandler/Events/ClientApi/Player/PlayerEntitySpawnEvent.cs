using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Player;

public abstract class PlayerEntitySpawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PlayerEntitySpawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IClientPlayer player);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerEntitySpawn += player => ExecuteEvent(instancesCreator, provider, player);
    }
}