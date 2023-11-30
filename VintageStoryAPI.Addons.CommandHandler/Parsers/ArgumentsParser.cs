using System.Reflection;
using Vintagestory.API.Common;
using VintageStoryAPI.Addons.CommandHandler.Common;
using VintageStoryAPI.Addons.CommandHandler.Parsers.CommandParameters;

namespace VintageStoryAPI.Addons.CommandHandler.Parsers;

internal class ArgumentsParser : IArgumentsParser
{
    private readonly CommandArgumentParsers _commandArgumentParsers;

    public ArgumentsParser(CommandArgumentParsers commandArgumentParsers)
    {
        _commandArgumentParsers = commandArgumentParsers;
    }

    public IEnumerable<ICommandArgumentParser> GetArgumentsFromParameters(IEnumerable<ParameterInfo> parameters)
    {
        var argumentParsers = new List<ICommandArgumentParser>();

        foreach (var parameter in parameters)
        {
            var attribute = parameter.GetCustomAttributes()
                .Where(attribute => attribute.GetType().IsAssignableTo(typeof(CommandParameterAttribute))).ToArray();
            if (attribute is null || attribute.Length != 1) throw new CustomAttributeFormatException("You must add one attribute to command parameter");
            argumentParsers.Add(ParseArgumentFromAttribute(attribute.First()));
        }

        return argumentParsers;
    }

    private ICommandArgumentParser ParseArgumentFromAttribute(Attribute attribute)
    {
        var attributeType = attribute.GetType();
        var parameters = attributeType.GetProperties()
            .Where(property => property.GetCustomAttribute<ArgsParserAttribute>() is not null)
            .Select(property => property.GetValue(attribute)).ToList();
        if (IsArgumentIsOptional(attribute))
        {
            parameters.AddRange(attributeType.GetProperties()
                .Where(property => property.GetCustomAttribute<OptionalArgsParserAttribute>() is not null)
                .Select(property => property.GetValue(attribute)));
        }
        var methodName = GetMethodNameFromAttribute(attribute);
        return (ICommandArgumentParser)
            _commandArgumentParsers.GetType()
                .GetMethods().First(method => method.Name == methodName && method.GetParameters().Length == parameters.Count)!.Invoke(_commandArgumentParsers, parameters.ToArray())!;
    }
    
    private string GetMethodNameFromAttribute(Attribute attribute)
    {
        var type = attribute.GetType();
        var propertyName = IsArgumentIsOptional(attribute) ? "OptionalMethodName" : "MethodName";
        return type.GetProperty(propertyName)!.GetValue(attribute)!.ToString()!;
    }

    private bool IsArgumentIsOptional(Attribute attribute)
    {
        var type = attribute.GetType();
        return type.GetInterface("IOptional", true) is not null && (bool)type
            .GetProperty("IsOptional")!.GetValue(attribute)!;
    }
    
    
}