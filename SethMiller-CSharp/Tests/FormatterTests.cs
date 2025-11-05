using SethMiller_CSharp.Logic;

namespace SethMiller_CSharp.Tests
{
    public partial class FormatterTests
    {
        [Fact]
        public void FormatObjectAsString_WhenGivenEmptyObject_ReturnsEmptyString()
        {
            // arrange
            var input = new ParsedObject();

            // act
            var result = Formatter.FormatObjectAsString(input);

            // assert
            Assert.True(string.IsNullOrEmpty(result));
        }

        [Fact]
        public void FormatObjectAsString_WhenSortingAndGivenEmptyObject_ReturnsEmptyString()
        {
            // arrange
            var input = new ParsedObject();

            // act
            var result = Formatter.FormatObjectAsString(input, true);

            // assert
            Assert.True(string.IsNullOrEmpty(result));
        }

        [Theory]
        [MemberData(nameof(TestCases))]
        public void FormatObjectAsString_WhenGivenObject_FormatsAsExpected(ParsedObject input, string expectation)
        {
            // act
            var result = Formatter.FormatObjectAsString(input);

            // assert
            Assert.Equivalent(expectation, result);
        }

        [Theory]
        [MemberData(nameof(SortedTestCases))]
        public void FormatObjectAsString_WhenSortingAndGivenObject_FormatsAsExpected(ParsedObject input, string expectation)
        {
            // act
            var result = Formatter.FormatObjectAsString(input, true);

            // assert
            Assert.Equivalent(expectation, result);
        }
    }
}