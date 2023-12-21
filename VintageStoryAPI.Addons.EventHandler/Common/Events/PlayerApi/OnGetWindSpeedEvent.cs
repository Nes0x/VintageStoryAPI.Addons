using Vintagestory.API.Client;
using Vintagestory.API.MathTools;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class OnGetWindSpeedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected OnGetWindSpeedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vec3d position, ref Vec3d windSpeed);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnGetWindSpeed += (Vec3d position, ref Vec3d windSpeed) =>
            ExecuteEvent(instancesCreator, provider, position, windSpeed);
    }
}