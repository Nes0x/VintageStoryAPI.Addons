using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Mouse;

public abstract class MouseUpEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected MouseUpEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(MouseEvent mouseEvent);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.MouseUp += mouseEvent => Execute(instanceCreator, provider, mouseEvent);
    }
}