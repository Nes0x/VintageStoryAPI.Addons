using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.Common.Extensions;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandParametersParser<T> : ICommandParametersParser<T> where T : ICoreAPI
{
    private readonly ExtendedCommandArgumentParser _commandArgumentParser;

    public CommandParametersParser(ExtendedCommandArgumentParser commandArgumentParser)
    {
        _commandArgumentParser = commandArgumentParser;
    }

    public IEnumerable<ICommandArgumentParser> GetCommandParametersFromParameters(IEnumerable<ParameterInfo> parameters)
    {
        var argumentParsers = new List<ICommandArgumentParser>();

        foreach (var parameter in parameters)
        {
            var attribute = parameter.GetCustomAttributes()
                .Where(attribute => attribute.GetType().IsAssignableTo(typeof(CommandParameterAttribute))).ToArray();
            if (attribute is null || attribute.Length != 1)
                throw new CustomAttributeFormatException("You must add one attribute to command parameter");
            argumentParsers.Add(ParseCommandParameterFromAttribute(attribute.First()));
        }

        return argumentParsers;
    }

    private ICommandArgumentParser ParseCommandParameterFromAttribute(Attribute attribute)
    {
        var parameters = attribute.ReadPropertiesFromAttribute<RequiredParameterAttribute>().ToArray();
        var methodName = GetMethodNameFromAttribute(attribute);
        var arguments = IsOptional(attribute)
            ? parameters.Concat(attribute.ReadPropertiesFromAttribute<OptionalParameterAttribute>()).ToArray()
            : parameters.ToArray();
        return (ICommandArgumentParser)
            _commandArgumentParser.GetType()
                .GetMethods()
                .First(method => method.Name == methodName && method.GetParameters().Length == arguments.Length)
                .Invoke(_commandArgumentParser, arguments)!;
    }

    private string GetMethodNameFromAttribute(Attribute attribute)
    {
        var type = attribute.GetType();
        var propertyName = IsOptional(attribute) ? "OptionalMethodName" : "MethodName";
        return type.GetProperty(propertyName)!.GetValue(attribute)!.ToString()!;
    }

    private bool IsOptional(Attribute attribute)
    {
        var type = attribute.GetType();
        return type.GetInterface("IOptional", true) is not null && (bool)type
            .GetProperty("IsOptional")!.GetValue(attribute)!;
    }
}