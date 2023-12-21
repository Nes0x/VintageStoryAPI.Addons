using Vintagestory.API.Common;
using Vintagestory.API.Common.Entities;
using Vintagestory.API.MathTools;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Player;

public abstract class OnPlayerInteractEntityEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected OnPlayerInteractEntityEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Entity entity,
        IPlayer player,
        ItemSlot slot,
        Vec3d hitPosition,
        int mode,
        ref EnumHandling handling);


    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnPlayerInteractEntity += (Entity entity,
                IPlayer player,
                ItemSlot slot,
                Vec3d hitPosition,
                int mode,
                ref EnumHandling handling) =>
            ExecuteEvent(instancesCreator, provider, entity, player, slot, hitPosition, mode, handling);
    }
}