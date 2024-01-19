using System.Reflection;

namespace VintageStoryAPI.Addons.CommandHandler.Common.Models;

public class ParsedInstance<TInstance> where TInstance : class, IContext
{
    public ParsedInstance(MethodInfo handler, IEnumerable<object?> arguments, TInstance instance)
    {
        Handler = handler;
        Arguments = arguments;
        Instance = instance;
    }

    public MethodInfo Handler { get; }
    public IEnumerable<object?> Arguments { get; }
    public TInstance Instance { get; }
}