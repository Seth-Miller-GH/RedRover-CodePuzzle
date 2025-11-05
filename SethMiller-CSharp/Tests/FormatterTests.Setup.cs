using SethMiller_CSharp.Logic;

namespace SethMiller_CSharp.Tests
{
    public partial class FormatterTests
    {
        public static TheoryData<ParsedObject, string> TestCases => new()
        {
            {
                new() { ["a"] = null, ["b"] = null },
                $"- a{Environment.NewLine}- b{Environment.NewLine}"
            },
            {
                new() { ["b"] = null, ["a"] = null },
                $"- b{Environment.NewLine}- a{Environment.NewLine}"
            },
            {
                new()
                {
                    ["a"] = null,
                    ["b"] = null,
                    ["c"] = new ParsedObject()
                    {
                        ["d"] = null,
                        ["e"] = null
                    },
                    ["f"] = null
                },
                $"- a{Environment.NewLine}- b{Environment.NewLine}- c{Environment.NewLine}  - d{Environment.NewLine}  - e{Environment.NewLine}- f{Environment.NewLine}"
            },
            {
                new()
                {
                    ["b"] = null,
                    ["a"] = null,
                    ["c"] = new ParsedObject()
                    {
                        ["d"] = new ParsedObject()
                        {
                            ["h"] = null
                        },
                        ["e"] = null
                    },
                    ["f"] = null
                },
                $"- b{Environment.NewLine}- a{Environment.NewLine}- c{Environment.NewLine}  - d{Environment.NewLine}    - h{Environment.NewLine}  - e{Environment.NewLine}- f{Environment.NewLine}"
            }
        };

        public static TheoryData<ParsedObject, string> SortedTestCases => new()
        {
            {
                new() { ["a"] = null, ["b"] = null },
                $"- a{Environment.NewLine}- b{Environment.NewLine}"
            },
            {
                new() { ["b"] = null, ["a"] = null },
                $"- a{Environment.NewLine}- b{Environment.NewLine}"
            },
            {
                new()
                {
                    ["a"] = null,
                    ["b"] = null,
                    ["c"] = new ParsedObject()
                    {
                        ["d"] = null,
                        ["e"] = null
                    },
                    ["f"] = null
                },
                $"- a{Environment.NewLine}- b{Environment.NewLine}- c{Environment.NewLine}  - d{Environment.NewLine}  - e{Environment.NewLine}- f{Environment.NewLine}"
            },
            {
                new()
                {
                    ["b"] = null,
                    ["a"] = null,
                    ["c"] = new ParsedObject()
                    {
                        ["d"] = new ParsedObject()
                        {
                            ["h"] = null
                        },
                        ["e"] = null
                    },
                    ["f"] = null
                },
                $"- a{Environment.NewLine}- b{Environment.NewLine}- c{Environment.NewLine}  - d{Environment.NewLine}    - h{Environment.NewLine}  - e{Environment.NewLine}- f{Environment.NewLine}"
            }
        };
    }
}