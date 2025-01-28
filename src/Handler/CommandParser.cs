using System.Collections.Generic;
using System.Text;

namespace FoxyCommands.Handler;

public static class CommandParser
{
  // thank you deepseek for this beauty
  public static string[] ParseCommand(string input)
  {
    // Remove leading slash if present
    if (input.StartsWith("/"))
      input = input.Substring(1);
    input = input.Trim();

    List<string> args = new List<string>();
    bool inQuotes = false;
    StringBuilder currentArg = new StringBuilder();

    foreach (char c in input)
    {
      if (inQuotes)
      {
        if (c == '"')
        {
          inQuotes = false;
        }
        else
        {
          currentArg.Append(c);
        }
      }
      else
      {
        switch (c)
        {
          case '"':
            inQuotes = true;
            break;
          case ' ':
            if (currentArg.Length > 0)
            {
              args.Add(currentArg.ToString());
              currentArg.Clear();
            }
            break;
          default:
            currentArg.Append(c);
            break;
        }
      }
    }

    // Add the final argument if any
    if (currentArg.Length > 0)
    {
      args.Add(currentArg.ToString());
    }

    return args.ToArray();
  }
}
