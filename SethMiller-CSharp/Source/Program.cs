using SethMiller_CSharp.Logic;

const string strValue = "(id, name, email, type(id, name, customFields(c1, c2, c3)), externalId)";

Console.WriteLine($"Original string: {strValue}");
Console.WriteLine();

Console.WriteLine("Formatted string:");
Console.WriteLine(Formatter.FormatObjectAsString(Parser.ParseString(strValue)));
Console.WriteLine();

Console.WriteLine("Sorted formatted string:");
Console.WriteLine(Formatter.FormatObjectAsString(Parser.ParseString(strValue), true));
Console.WriteLine();