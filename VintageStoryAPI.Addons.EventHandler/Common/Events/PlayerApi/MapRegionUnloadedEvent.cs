using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class MapRegionUnloadedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
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