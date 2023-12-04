using System.Reflection;

namespace VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters.Validators;

internal class CommandParametersValidator : ICommandParametersValidator
{
    public bool HasRequiredAttribute(ParameterInfo parameter, out Attribute? attribute)
    {
        attribute = null;
        var attributes = parameter.GetCustomAttributes()
            .Where(attribute => attribute.GetType().IsAssignableTo(typeof(CommandParameterAttribute))).ToArray();
        if (attributes.Length != 1) return false;
        attribute = attributes.First();
        return true;
    }

    public bool IsOptional(Attribute attribute)
    {
        var type = attribute.GetType();
        return type.GetInterface("IOptional", true) is not null && (bool)type
            .GetProperty("IsOptional")!.GetValue(attribute)!;
    }
}