using SethMiller_CSharp.Logic;

namespace SethMiller_CSharp.Tests
{
    public class ParserTests
    {
        [Fact]
        public void ParseString_WhenGivenEmptyString_ReturnsEmptyObject()
        {
            // arrange
            var input = "";

            // act
            var result = Parser.ParseString(input);

            // assert
            Assert.Equivalent(new ParsedObject(), result);
        }

        [Fact]
        public void ParseString_WhenGivenEmptyObjectString_ReturnsEmptyObject()
        {
            // arrange
            var input = "()";

            // act
            var result = Parser.ParseString(input);

            // assert
            Assert.Equivalent(new ParsedObject(), result);
        }

        [Fact]
        public void ParseString_WhenGivenSimpleString_ReturnsSimpleObject()
        {
            // arrange
            var input = "(a, b)";
            var expected = new ParsedObject()
            {
                ["a"] = null,
                ["b"] = null
            };

            // act
            var result = Parser.ParseString(input);

            // assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public void ParseString_WhenGivenNestedString_ReturnsNestedObject()
        {
            // arrange
            var input = "(a, b, c(d, e), f, g(h, i(j, k)), l)";
            var expected = new ParsedObject()
            {
                ["a"] = null,
                ["b"] = null,
                ["c"] = new ParsedObject()
                {
                    ["d"] = null,
                    ["e"] = null
                },
                ["f"] = null,
                ["g"] = new ParsedObject()
                {
                    ["h"] = null,
                    ["i"] = new ParsedObject()
                    {
                        ["j"] = null,
                        ["k"] = null
                    }
                },
                ["l"] = null
            };

            // act
            var result = Parser.ParseString(input);

            // assert
            Assert.Equivalent(expected, result);
        }

        [Fact]
        public void ParseString_WhenGivenSimpleStringWithDuplicates_ReturnsSimpleObject()
        {
            // arrange
            var input = "(a, b, a)";
            var expected = new ParsedObject()
            {
                ["a"] = null,
                ["b"] = null
            };

            // act
            var result = Parser.ParseString(input);

            // assert
            Assert.Equivalent(expected, result);
        }
    }
}
