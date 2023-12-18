using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events;

public abstract class PlayerDeathEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected PlayerDeathEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IClientPlayer player);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.PlayerJoin += player =>
        {
            var instance = instancesCreator.CreateInstance(GetType(), provider);
            GetType().GetMethod("Handle")!.Invoke(instance, new object[] { player });
        };
    }
}