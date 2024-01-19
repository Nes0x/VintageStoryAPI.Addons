using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class PlayerDeathEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected PlayerDeathEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player, DamageSource damageSource);


    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.PlayerDeath += (player, damageSource) =>
            Execute(instanceCreator, provider, player, damageSource);
    }
}