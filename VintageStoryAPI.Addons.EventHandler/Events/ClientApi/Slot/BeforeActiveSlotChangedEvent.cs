using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Slot;

public abstract class BeforeActiveSlotChangedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected BeforeActiveSlotChangedEvent(TApi api) : base(api)
    {
    }

    public abstract EnumHandling Handle(ActiveSlotChangeEventArgs activeSlotChangeEventArgs);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.BeforeActiveSlotChanged += activeSlotChangeEventArgs =>
            (EnumHandling)ExecuteEvent(instancesCreator, provider, activeSlotChangeEventArgs)!;
    }
}