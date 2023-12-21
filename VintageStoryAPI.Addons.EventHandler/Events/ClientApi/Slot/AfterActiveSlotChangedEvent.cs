using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Slot;

public abstract class AfterActiveSlotChangedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected AfterActiveSlotChangedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(ActiveSlotChangeEventArgs activeSlotChangeEventArgs);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.AfterActiveSlotChanged += activeSlotChangeEventArgs =>
            ExecuteEvent(instancesCreator, provider, activeSlotChangeEventArgs);
    }
}