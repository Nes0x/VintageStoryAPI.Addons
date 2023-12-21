using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class OnGetClimateEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected OnGetClimateEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(ref ClimateCondition climate,
        BlockPos pos,
        EnumGetClimateMode mode,
        double totalDays);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnGetClimate += (ref ClimateCondition climate,
                BlockPos blockPosition,
                EnumGetClimateMode climateMode,
                double totalDays) =>
            ExecuteEvent(instancesCreator, provider, climate, blockPosition, climateMode, totalDays);
    }
}