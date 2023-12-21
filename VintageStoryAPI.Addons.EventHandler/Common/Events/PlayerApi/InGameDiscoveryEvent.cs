using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class InGameDiscoveryEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected InGameDiscoveryEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(object sender, string discoveryCode, string text);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.InGameDiscovery += (sender, discoveryCode, text) =>
            ExecuteEvent(instancesCreator, provider, sender, discoveryCode, text);
    }
}