using FoxyCommands.Commands;

namespace FoxyCommands.Handler;

public static class CommandRegistry
{
  public static Command[] Commands { get; } = [
    new HelpCommand(),
    new CreditsCommand(),
  ];
}
