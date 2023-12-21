using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class InGameErrorEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected InGameErrorEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(object sender, string errorCode, string text);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.InGameError += (sender, errorCode, text) =>
            ExecuteEvent(instancesCreator, provider, sender, errorCode, text);
    }
}