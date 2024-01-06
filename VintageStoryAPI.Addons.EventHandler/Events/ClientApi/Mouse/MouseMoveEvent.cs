using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Mouse;

public abstract class MouseMoveEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected MouseMoveEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(MouseEvent mouseEvent);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.MouseMove += mouseEvent => Execute(instanceCreator, provider, mouseEvent);
    }
}