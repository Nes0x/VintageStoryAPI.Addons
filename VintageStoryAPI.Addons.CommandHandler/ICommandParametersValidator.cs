using System.Reflection;

namespace VintageStoryAPI.Addons.CommandHandler;

public interface ICommandParametersValidator
{
    bool IsOptional(Attribute attribute);
    bool HasRequiredAttribute(ParameterInfo parameter, out Attribute? attribute);
}