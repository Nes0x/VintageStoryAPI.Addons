using System.Reflection;

namespace VintageStoryAPI.Addons.CommandHandler.Common;

public class ParsedInstance<TInstance> where TInstance : class, IContext
{
    public MethodInfo Handler { get; }
    public IEnumerable<object?> Arguments { get; }
    public TInstance Instance { get; }

    public ParsedInstance(MethodInfo handler, IEnumerable<object?> arguments, TInstance instance)
    {
        Handler = handler;
        Arguments = arguments;
        Instance = instance;
    }
}