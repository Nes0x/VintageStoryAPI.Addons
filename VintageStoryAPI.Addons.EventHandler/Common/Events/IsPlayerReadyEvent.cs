using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events;

public abstract class IsPlayerReadyEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected IsPlayerReadyEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle(ref EnumHandling handling);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.IsPlayerReady += (ref EnumHandling handling) =>
        {
            var instance = instancesCreator.CreateInstance(GetType(), provider);
            return (bool)GetType().GetMethod("Handle")!.Invoke(instance, new object[] { handling })!;
        };
    }
}