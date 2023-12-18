using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events;

public abstract class OnSendChatMessageEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected OnSendChatMessageEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(ref EnumHandling handling);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnSendChatMessage += (int groupId,
            ref string message,
            ref EnumHandling handled) =>
        {
            var instance = instancesCreator.CreateInstance(GetType(), provider);
            GetType().GetMethod("Handle")!.Invoke(instance, new object[] { groupId, message, handled});
        };
    }
}