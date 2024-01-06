using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Game;

public abstract class InGameErrorEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected InGameErrorEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(object sender, string errorCode, string text);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.InGameError += (sender, errorCode, text) =>
            Execute(instanceCreator, provider, sender, errorCode, text);
    }
}