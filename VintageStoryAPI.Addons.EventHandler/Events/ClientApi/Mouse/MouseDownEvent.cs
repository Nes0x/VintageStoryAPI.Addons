using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Mouse;

public abstract class MouseDownEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected MouseDownEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(MouseEvent mouseEvent);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.MouseDown += mouseEvent => ExecuteEvent(instancesCreator, provider, mouseEvent);
    }
}