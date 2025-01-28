using FoxyCommands.Handler;
using HarmonyLib;
using System;

namespace FoxyCommands.Patches;

[HarmonyPatch(typeof(HUDManager))]
public class HUDManagerPatch
{
  [HarmonyPatch("AddTextToChatOnServer")]
  [HarmonyPrefix]
  private static bool ChatPrefix(string chatMessage, int playerId, HUDManager __instance)
  {
    if (playerId == -1) return true;
    if (!RoundManager.Instance.IsHost) return true;

    FoxyCommands.Logger.LogInfo($"chatMessage: {chatMessage}, playerId: {playerId}");

    if (!chatMessage.Trim().StartsWith("/"))
      return true;

    string[] parsed = CommandParser.ParseCommand(chatMessage);
    string commandName = parsed[0];
    string[] args = parsed[1..^0];

    var command = Array.Find(CommandRegistry.Commands, cmd => cmd.Name.ToLower() == commandName.ToLower());
    if (command == null)
    {
      ChatManager.Error($"unknown command '{commandName}'");
      return false;
    }

    command.Handle(args);
    return false;
  }
}
