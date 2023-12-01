namespace VintageStoryAPI.Addons.CommandHandler.Creators;

internal interface IInstancesCreator
{
    object? CreateInstance(Type type);
}