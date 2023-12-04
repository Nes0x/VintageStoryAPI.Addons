using System.Reflection;

namespace VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters.Validators;

internal interface ICommandParametersValidator
{
    bool IsOptional(Attribute attribute);
    bool HasRequiredAttribute(ParameterInfo parameter, out Attribute? attribute);
}