using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class ChatMessageEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected ChatMessageEvent(TApi api) : base(api)
    {
    }

    public abstract void Handle(int groupId,
        string message,
        EnumChatType chatType,
        string data);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.ChatMessage += (groupId,
            message,
            chatType,
            data) => ExecuteEvent(instancesCreator, provider, groupId, message, chatType, data);
    }
}