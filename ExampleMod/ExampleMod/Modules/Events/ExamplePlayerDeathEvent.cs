using Vintagestory.API.Client;
using VintageStoryAPI.Addons.EventHandler.Common.Events;
using VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

namespace ExampleMod.Modules.Events;

public class ExamplePlayerDeathEvent : PlayerDeathEvent<ICoreClientAPI>
{
    public ExamplePlayerDeathEvent(ICoreClientAPI api) : base(api)
    {
    }

    public override void Handle(IClientPlayer player)
    {
        player.ShowChatNotification("test");
    }
}