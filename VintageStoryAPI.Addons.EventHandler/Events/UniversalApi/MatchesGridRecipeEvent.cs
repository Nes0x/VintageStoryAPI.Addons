using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.EventHandler.Events.UniversalApi;

public abstract class MatchesGridRecipeEvent<TApi> : BaseEvent<TApi> where TApi : ICoreAPI
{
    protected MatchesGridRecipeEvent(TApi api) : base(api)
    {
    }

    public abstract bool Handle(IPlayer player,
        GridRecipe recipe,
        ItemSlot[] ingredients,
        int gridWidth);

    public override void Subscribe(IInstanceCreator instanceCreator, IServiceProvider provider)
    {
        Api.Event.MatchesGridRecipe += (player,
            recipe,
            ingredients,
            gridWidth) => (bool)Execute(instanceCreator, provider, player, recipe, ingredients, gridWidth)!;
    }
}