using Vintagestory.API.Client;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Reload;

public abstract class ReloadShaderEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected ReloadShaderEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle();

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.ReloadShader += () => (bool)Execute(instanceCreator, provider)!;
    }
}