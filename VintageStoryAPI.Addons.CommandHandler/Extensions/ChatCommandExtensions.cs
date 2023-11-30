using Vintagestory.API.Common;

namespace VintageStoryAPI.Addons.CommandHandler.Extensions;

public static class ChatCommandExtensions
{
    /// <summary>If return value is error, command cannot be executed</summary>
    /// <param name="chatCommand"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static IChatCommand WithNullablePreCondition(this IChatCommand chatCommand, CommandPreconditionDelegate? p)
    {
        if (p is not null) chatCommand.WithPreCondition(p);
        return chatCommand;
    }

    /// <summary>Registers alternative names for this command</summary>
    /// <param name="chatCommand"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static IChatCommand WithNullableAlias(this IChatCommand chatCommand, params string[]? name)
    {
        if (name is not null && name.Length != 0) chatCommand.WithAlias(name);
        return chatCommand;
    }

    /// <summary>
    ///     Registers an alternative name for this command, always at the root level, i.e. /name
    /// </summary>
    /// <param name="chatCommand"></param>
    /// <param name="name"></param>
    /// <returns></returns>
    public static IChatCommand WithNullableRootAlias(this IChatCommand chatCommand, string? name)
    {
        if (name is not null) chatCommand.WithRootAlias(name);
        return chatCommand;
    }

    /// <summary>Set command description</summary>
    /// <param name="chatCommand"></param>
    /// <param name="description"></param>
    /// <returns></returns>
    public static IChatCommand WithNullableDescription(this IChatCommand chatCommand, string? description)
    {
        if (description is not null) chatCommand.WithDescription(description);
        return chatCommand;
    }

    /// <summary>
    ///     Set additional detailed command description, for command-specific help
    /// </summary>
    /// <param name="chatCommand"></param>
    /// <param name="detail"></param>
    /// <returns></returns>
    public static IChatCommand WithNullableAdditionalInformation(this IChatCommand chatCommand, string? detail)
    {
        if (detail is not null) chatCommand.WithAdditionalInformation(detail);
        return chatCommand;
    }

    /// <summary>
    ///     Define one ore more examples on how this command can be executed
    /// </summary>
    /// <param name="chatCommand"></param>
    /// <param name="examples"></param>
    /// <returns></returns>
    public static IChatCommand WithNullableExamples(this IChatCommand chatCommand, params string[]? examples)
    {
        if (examples is not null && examples.Length != 0) chatCommand.WithExamples(examples);
        return chatCommand;
    }

    /// <summary>
    ///     Define command arguments, you'd usually want to use one of the parsers supplied from from capi.ChatCommands.Parsers
    /// </summary>
    /// <param name="chatCommand"></param>
    /// <param name="args"></param>
    /// <returns></returns>
    public static IChatCommand WithNullableArgs(this IChatCommand chatCommand, params ICommandArgumentParser[]? args)
    {
        if (args is not null && args.Length != 0) chatCommand.WithArgs(args);
        return chatCommand;
    }

    /// <summary>
    ///     Define the required privilege to run this command / subcommand
    /// </summary>
    /// <param name="chatCommand"></param>
    /// <param name="privilege"></param>
    /// <returns></returns>
    public static IChatCommand RequiresNullablePrivilege(this IChatCommand chatCommand, string? privilege)
    {
        if (privilege is not null) chatCommand.RequiresPrivilege(privilege);
        return chatCommand;
    }

    /// <summary>
    ///     This command can only be run if the caller is a player
    /// </summary>
    /// <returns></returns>
    public static IChatCommand RequiresNullablePlayer(this IChatCommand chatCommand, bool? required)
    {
        if (required is not null && required.Value) chatCommand.RequiresPlayer();
        return chatCommand;
    }
}