using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi.World;

public abstract class MapRegionLoadedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected MapRegionLoadedEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle(Vec2i mapCoordinates, IMapRegion region);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.MapRegionLoaded += (mapCoordinates, region) =>
            ExecuteEvent(instancesCreator, provider, mapCoordinates, region);
    }
}