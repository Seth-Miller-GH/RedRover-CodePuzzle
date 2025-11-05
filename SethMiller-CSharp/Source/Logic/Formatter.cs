namespace SethMiller_CSharp.Logic
{
    public static class Formatter
    {
        public static readonly int IndentSize = 2;

        public static string FormatObjectAsString(ParsedObject obj, bool shouldSort = false, int indentationLevel = 0)
        {
            var result = "";
            var indent = new string(' ', indentationLevel * IndentSize);
            var keys = shouldSort ? obj.Keys.Order().AsEnumerable() : obj.Keys;

            foreach (var k in keys)
            {
                var nestedObjectResult = obj[k] != null ?
                    FormatObjectAsString(obj[k]!, shouldSort, indentationLevel + 1) 
                    : "";
                result += $"{indent}- {k}{Environment.NewLine}{nestedObjectResult}";
            }

            return result;
        }
    }
}
