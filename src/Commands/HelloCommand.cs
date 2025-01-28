using FoxyCommands.Handler;

namespace FoxyCommands.Commands;

public class HelloCommand : Command
{
  public HelloCommand() : base("hello") { }

  public override void Handle(string[] args)
  {
    ChatManager.Info("hello world! :3");
  }
}
