namespace VintageStoryAPI.Addons.Common.Creators;

public interface IInstanceCreator
{
    object? Create(Type type, IServiceProvider? provider);
}