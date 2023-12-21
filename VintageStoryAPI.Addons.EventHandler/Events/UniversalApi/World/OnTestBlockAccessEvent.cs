using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi.World;

public abstract class OnTestBlockAccessEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected OnTestBlockAccessEvent(TApi api) : base(api)
    {
    }

    public abstract EnumWorldAccessResponse Handle(IPlayer player,
        BlockSelection blockSel,
        EnumBlockAccessFlags accessType,
        string claimant,
        EnumWorldAccessResponse response);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnTestBlockAccess += (player,
                blockSelection,
                accessType,
                claimant,
                response)
            => (EnumWorldAccessResponse)ExecuteEvent(instancesCreator, provider, player,
                blockSelection, accessType, claimant, response)!;
    }
}