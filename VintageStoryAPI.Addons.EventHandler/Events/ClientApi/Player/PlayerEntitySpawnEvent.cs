using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Player;

public abstract class PlayerEntitySpawnEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PlayerEntitySpawnEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IClientPlayer player);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.PlayerEntitySpawn += player => Execute(instanceCreator, provider, player);
    }
}