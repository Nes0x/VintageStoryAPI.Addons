namespace VintageStoryAPI.Addons.Common.Creators;

public interface IInstancesCreator
{
    object? CreateInstance(Type type, IServiceProvider? provider);
    object? CreateInstance(Type type);
}