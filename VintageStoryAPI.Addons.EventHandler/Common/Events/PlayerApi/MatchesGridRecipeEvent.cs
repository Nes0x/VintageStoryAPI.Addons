using Vintagestory.API.Client;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.Common.Creators;

namespace VintageStoryAPI.Addons.EventHandler.Common.Events.PlayerApi;

public abstract class MatchesGridRecipeEvent<TApi> : BaseEvent<TApi> where TApi : ICoreClientAPI
{
    protected MatchesGridRecipeEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle(IPlayer player,
        GridRecipe recipe,
        ItemSlot[] ingredients,
        int gridWidth);

    public override void Subscribe(IInstancesCreator instancesCreator, IServiceProvider provider)
    {
        Api.Event.MatchesGridRecipe += (player,
            recipe,
            ingredients,
            gridWidth) => (bool)ExecuteEvent(instancesCreator, provider, player, recipe, ingredients, gridWidth)!;
    }
}