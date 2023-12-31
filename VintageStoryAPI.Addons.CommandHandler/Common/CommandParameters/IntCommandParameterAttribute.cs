﻿namespace VintageStoryAPI.Addons.CommandHandler.Common.CommandParameters;

public class IntCommandParameterAttribute : CommandParameterAttribute, IOptional
{
    public IntCommandParameterAttribute(string name, int defaultValue = 0, bool isOptional = false)
    {
        Name = name;
        DefaultValue = defaultValue;
        IsOptional = isOptional;
    }

    public override string Name { get; }
    [OptionalParameter] public int DefaultValue { get; }
    public override string MethodName => "Int";
    public string OptionalMethodName => "OptionalInt";
    public bool IsOptional { get; }
}