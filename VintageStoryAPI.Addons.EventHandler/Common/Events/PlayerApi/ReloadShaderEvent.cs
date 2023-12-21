using Vintagestory.API.Client;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class ReloadShaderEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected ReloadShaderEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle();

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.ReloadShader += () => (bool)ExecuteEvent(instancesCreator, provider)!;
    }
}