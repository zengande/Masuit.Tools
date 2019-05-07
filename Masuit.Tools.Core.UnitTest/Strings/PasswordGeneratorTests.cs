using Masuit.Tools.Core.Strings;
using Xunit;

namespace Masuit.Tools.Core.UnitTest.Strings
{
    public class PasswordGeneratorTests
    {
        [Fact]
        public void NoParameterGenerateMethodTest()
        {
            // Act
            var password = PasswordGenerator.Generate();

            // Assert
            Assert.Equal(PasswordOptions.Default.Length, password.Length);
        }

        [Fact]
        public void OptionsGenerateMethodTest()
        {
            // Act
            var options = new PasswordOptions(16, true, true);
            var password = PasswordGenerator.Generate(options);

            // Assert
            Assert.Equal(options.Length, password.Length);
        }
    }
}
