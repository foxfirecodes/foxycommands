using HarmonyLib;

namespace FoxyCommands.Patches;

[HarmonyPatch(typeof(HUDManager))]
public class HUDManagerPatch
{
    [HarmonyPatch("AddTextToChatOnServer")]
    [HarmonyPrefix]
    private static void ChatPrefix(string chatMessage, int playerId, HUDManager __instance)
    {
        if (playerId == -1) return;

        FoxyCommands.Logger.LogInfo($"got chat message from {playerId}: {chatMessage}");
    }
}
