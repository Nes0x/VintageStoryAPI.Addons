namespace VintageStoryAPI.Addons.CommandHandler.Common;

[AttributeUsage(AttributeTargets.Method)]
public class SubCommandAttribute : Attribute
{
    public SubCommandAttribute(string baseCommandName)
    {
        BaseCommandName = baseCommandName;
    }

    public string BaseCommandName { get; }
}