using Vintagestory.API.Common;
using Vintagestory.API.MathTools;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi.World;

public abstract class OnGetWindSpeedEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected OnGetWindSpeedEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(Vec3d position, ref Vec3d windSpeed);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.OnGetWindSpeed += (Vec3d position, ref Vec3d windSpeed) =>
            Execute(instanceCreator, provider, position, windSpeed);
    }
}