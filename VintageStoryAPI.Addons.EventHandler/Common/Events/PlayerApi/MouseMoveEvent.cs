using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class MouseMoveEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected MouseMoveEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(MouseEvent mouseEvent);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.MouseMove += mouseEvent => ExecuteEvent(instancesCreator, provider, mouseEvent);
    }
}