using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Chat;

public abstract class OnSendChatMessageEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected OnSendChatMessageEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(int groupId,
        ref string message,
        ref EnumHandling handled);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.OnSendChatMessage += (int groupId,
            ref string message,
            ref EnumHandling handled) => ExecuteEvent(instancesCreator, provider, groupId, message, handled);
    }
}