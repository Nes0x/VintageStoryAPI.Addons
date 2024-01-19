using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.Models;
using VintageStoryAPI.Addons.CommandHandler.Parsers;

namespace VintageStoryAPI.Addons.CommandHandler.Factories;

internal class ParsedInstanceFactory
{
    private readonly ICommandArgumentsParser _commandArgumentParser;
    private readonly InstanceFactory _instanceFactory;

    public ParsedInstanceFactory(ICommandArgumentsParser commandArgumentParser, InstanceFactory instanceFactory)
    {
        _commandArgumentParser = commandArgumentParser;
        _instanceFactory = instanceFactory;
    }

    public ParsedInstance<TInstance> Create<TInstance>(MethodInfo handler, TextCommandCallingArgs context)
        where
        TInstance : class, IContext
    {
        var arguments = _commandArgumentParser.ParseAll(context.Parsers, handler.GetParameters());
        var instance = _instanceFactory.Create<TInstance>(handler.DeclaringType!, context);
        return new ParsedInstance<TInstance>(handler, arguments, instance);
    }
}