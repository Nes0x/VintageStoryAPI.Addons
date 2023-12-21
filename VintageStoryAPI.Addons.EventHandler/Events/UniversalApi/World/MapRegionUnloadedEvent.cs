using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi.World;

public abstract class MapRegionUnloadedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected MapRegionUnloadedEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle(Vec2i mapCoordinates, IMapRegion region);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.MapRegionUnloaded += (mapCoordinates, region) =>
            ExecuteEvent(instancesCreator, provider, mapCoordinates, region);
    }
}