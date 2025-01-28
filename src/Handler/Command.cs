
namespace FoxyCommands.Handler;

public abstract class Command
{

  public string Name { get; private set; }

  public Command(string name)
  {
    this.Name = name;
  }

  public abstract void Handle(string[] args);
}

