using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Slot;

public abstract class AfterActiveSlotChangedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected AfterActiveSlotChangedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(IServerPlayer player, ActiveSlotChangeEventArgs activeSlotChangeEventArgs);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.AfterActiveSlotChanged += (player, activeSlotChangeEventArgs) =>
            ExecuteEvent(instancesCreator, provider, player, activeSlotChangeEventArgs);
    }
}