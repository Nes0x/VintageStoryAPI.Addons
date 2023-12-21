using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class OnTestBlockAccessEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
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