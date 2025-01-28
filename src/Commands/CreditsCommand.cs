using FoxyCommands.Handler;

namespace FoxyCommands.Commands;

public class CreditsCommand : Command
{
  public CreditsCommand() : base("credits") { }

  public override void Handle(string[] args)
  {
    if (args.Length < 1)
    {
      ChatManager.Error("usage: /credits <amount>");
      return;
    }

    int amount;
    try
    {
      amount = int.Parse(args[0]);
    }
    catch (System.Exception)
    {
      ChatManager.Error($"invalid amount '{args[0]}'");
      return;
    }

    Terminal terminal = (Terminal)UnityEngine.Object.FindObjectOfType(typeof(Terminal));
    terminal.SyncGroupCreditsServerRpc(amount, terminal.numberOfItemsInDropship);
    ChatManager.Info($"set credits to {amount}");
  }
}
