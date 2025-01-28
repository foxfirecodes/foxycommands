
namespace FoxyCommands.Handler;

public abstract class Command
{

  public string Name { get; private set; }
  public string Usage { get; private set; }

  public Command(string name, string usage)
  {
    this.Name = name;
    this.Usage = usage;
  }

  public void SendUsage()
  {
    ChatManager.Error($"usage: /{this.Name} {this.Usage}");
  }

  public abstract void Handle(string[] args);
}

