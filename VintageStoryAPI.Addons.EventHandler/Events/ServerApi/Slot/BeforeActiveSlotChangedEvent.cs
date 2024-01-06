using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Slot;

public abstract class BeforeActiveSlotChangedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected BeforeActiveSlotChangedEvent(TApi api) : base(api)
    {
    }

    public abstract EnumHandling Handle(IServerPlayer player, ActiveSlotChangeEventArgs activeSlotChangeEventArgs);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.BeforeActiveSlotChanged += (player, activeSlotChangeEventArgs) =>
            (EnumHandling)Execute(instanceCreator, provider, player, activeSlotChangeEventArgs)!;
    }
}