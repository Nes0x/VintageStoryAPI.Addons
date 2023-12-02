using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Extensions;
using VintageStoryAPI.Addons.Common.Extensions;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class CommandParametersParser : ICommandParametersParser
{
    private readonly ExtendedCommandArgumentParser _commandArgumentParser;
    private readonly ICommandParametersValidator _commandParametersValidator;

    public CommandParametersParser(ExtendedCommandArgumentParser commandArgumentParser,
        ICommandParametersValidator commandParametersValidator)
    {
        _commandArgumentParser = commandArgumentParser;
        _commandParametersValidator = commandParametersValidator;
    }

    public IEnumerable<ICommandArgumentParser> GetCommandParametersFromParameters(IEnumerable<ParameterInfo> parameters)
    {
        var parameterParsers = new List<ICommandArgumentParser>();

        foreach (var parameter in parameters)
        {
            if (!_commandParametersValidator.HasRequiredAttribute(parameter, out var attribute))
                throw new CustomAttributeFormatException("You must add one attribute to command parameter");
            parameterParsers.Add(GetCommandParameterFromAttribute(attribute!));
        }

        return parameterParsers;
    }

    private ICommandArgumentParser GetCommandParameterFromAttribute(Attribute attribute)
    {
        var parameters = attribute.ReadPropertiesByAttribute<RequiredParameterAttribute>().ToArray();
        var methodName = GetMethodNameFromAttribute(attribute);
        var arguments = _commandParametersValidator.IsOptional(attribute)
            ? parameters.Concat(attribute.ReadPropertiesByAttribute<OptionalParameterAttribute>()).ToArray()
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
        var propertyName = _commandParametersValidator.IsOptional(attribute) ? "OptionalMethodName" : "MethodName";
        return type.GetProperty(propertyName)!.GetValue(attribute)!.ToString()!;
    }
}