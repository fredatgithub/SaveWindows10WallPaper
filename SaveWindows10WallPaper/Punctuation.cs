using System;
namespace SaveWindows10WallPaper
{
  public static class Punctuation
  {
    public const string Comma = ",";
    public const string Colon = ":";
    public const string OneSpace = " ";
    public const string Dash = "-";
    public const string UnderScore = "_";
    public const string SignAt = "@";
    public const string Ampersand = "&";
    public const string SignSharp = "#";
    public const string Period = ".";
    public const string Backslash = "\\";
    public const string Slash = "/";
    public const string OpenParenthesis = "(";
    public const string CloseParenthesis = ")";
    public const string OpenCurlyBrace = "{";
    public const string CloseCurlyBrace = "}";
    public const string OpenSquareBracket = "[";
    public const string CloseSquareBracket = "]";
    public const string LessThan = "<";
    public const string GreaterThan = ">";
    public const string DoubleQuote = "\"";
    public const string SimpleQuote = "'";
    public const string Tilde = "~";
    public const string Pipe = "|";
    public const string Plus = "+";
    public const string Minus = "-";
    public const string Multiply = "*";
    public const string Divide = "/";
    public const string Dollar = "$";
    public const string Pound = "£";
    public const string Percent = "%";
    public const string QuestionMark = "?";
    public const string ExclamationPoint = "!";
    public const string Chapter = "§";
    public const string Micro = "µ";
    public static string CrLf = Environment.NewLine;

    public static string Tabulate(ushort numberOfTabulation = 1)
    {
      string result = string.Empty;
      for (int number = 0; number < numberOfTabulation; number++)
      {
        result += " ";
      }

      return result;
    }
  }
}