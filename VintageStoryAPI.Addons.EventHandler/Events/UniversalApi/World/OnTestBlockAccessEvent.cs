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

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.OnTestBlockAccess += (player,
                blockSelection,
                accessType,
                claimant,
                response)
            => (EnumWorldAccessResponse)Execute(instanceCreator, provider, player,
                blockSelection, accessType, claimant, response)!;
    }
}