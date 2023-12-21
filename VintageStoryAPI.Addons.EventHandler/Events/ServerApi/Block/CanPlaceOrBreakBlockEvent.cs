using Vintagestory.API.Common;
using Vintagestory.API.Server;

namespace VintageStoryAPI.Addons.EventHandler.Events.ServerApi.Block;

public abstract class CanPlaceOrBreakBlockEvent<TApi> : BaseEvent<TApi> where TApi : ICoreServerAPI
{
    protected CanPlaceOrBreakBlockEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle( IServerPlayer player,
        BlockSelection blockSelection,
        out string claimant);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.CanPlaceOrBreakBlock += ( IServerPlayer player,
            BlockSelection blockSelection,
            out string claimant) =>
        {
            claimant = null!;
            return (bool)ExecuteEvent(instancesCreator, provider, player, blockSelection, claimant)!;
        };
    }
}