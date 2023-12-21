using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class MouseUpEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected MouseUpEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(MouseEvent mouseEvent);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.MouseUp += mouseEvent => ExecuteEvent(instancesCreator, provider, mouseEvent);
    }
}