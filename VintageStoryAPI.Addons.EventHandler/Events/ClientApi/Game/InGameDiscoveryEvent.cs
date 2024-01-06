using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Game;

public abstract class InGameDiscoveryEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected InGameDiscoveryEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(object sender, string discoveryCode, string text);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.InGameDiscovery += (sender, discoveryCode, text) =>
            Execute(instanceCreator, provider, sender, discoveryCode, text);
    }
}