using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class MapRegionLoadedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
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