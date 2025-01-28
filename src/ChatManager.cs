namespace FoxyCommands;

public static class ChatManager
{
  private static void DisplayChatMessage(string contents)
  {
    HUDManager.Instance.ChatMessageHistory.Add($"<color=#AA00FF>[FC]</color> {contents}");
    HUDManager.Instance.chatText.text = string.Join("\n", HUDManager.Instance.ChatMessageHistory);
  }

  public static void Info(string contents)
  {
    DisplayChatMessage($"<color=#55FFAA>{contents}</color>");
  }

  public static void Error(string contents)
  {
    DisplayChatMessage($"<color=#FF6600>{contents}</color>");
  }

}
