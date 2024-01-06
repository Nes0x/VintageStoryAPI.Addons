using Vintagestory.API.Client;
using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.ClientApi.Chat;

public abstract class ChatMessageEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected ChatMessageEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(int groupId,
        string message,
        EnumChatType chatType,
        string data);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.ChatMessage += (groupId,
            message,
            chatType,
            data) => Execute(instanceCreator, provider, groupId, message, chatType, data);
    }
}