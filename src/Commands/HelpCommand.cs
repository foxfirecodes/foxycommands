using System.Text;
using FoxyCommands.Handler;

namespace FoxyCommands.Commands;

public class HelpCommand : Command
{
  public HelpCommand() : base("help", "") { }

  public override void Handle(string[] args)
  {
    StringBuilder builder = new StringBuilder("available commands:");
    foreach (var cmd in CommandRegistry.Commands)
    {
      builder.Append($"\n/{cmd.Name} {cmd.Usage}");
    }
    ChatManager.Info(builder.ToString());
  }
}
