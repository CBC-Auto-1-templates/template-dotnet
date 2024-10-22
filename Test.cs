using Xunit;

namespace template_dotnet
{
    public class Test
    {
        [Theory]
        [InlineData("", "Hello World!")]
        [InlineData("Space", "Hello Space!")]
        public void TestSayHello(string input, string expected)
        {
            var actual = HelloSayer.SayHello(input);
            Assert.Equal(expected, actual);
        }
    }
}
