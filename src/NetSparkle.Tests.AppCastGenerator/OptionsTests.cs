using CommandLine;
using NetSparkleUpdater.AppCastGenerator;
using Xunit;

namespace NetSparkle.Tests.AppCastGenerator
{
    public class OptionsTests
    {
        [Fact]
        public void ParseArguments_NoKeyOverrideInitially()
        {
            var args = new[]
            {
                "--generate-signature", "binary.exe",
            };

            var result = Parser.Default.ParseArguments<Options>(args);

            Assert.Empty(result.Errors);
            Assert.Equal("", result.Value.PublicKeyOverride);
            Assert.Equal("", result.Value.PrivateKeyOverride);
        }

        [Fact]
        public void ParseArguments_KeysOverrideAndGenerateSignature_Compatibility()
        {
            var args = new[]
            {
                "--generate-signature", "binary.exe",
                "--public-key-override", "TestPublicKey",
                "--private-key-override", "TestPrivateKey"
            };

            var result = Parser.Default.ParseArguments<Options>(args);

            Assert.Empty(result.Errors);
            Assert.Equal("TestPublicKey", result.Value.PublicKeyOverride);
            Assert.Equal("TestPrivateKey", result.Value.PrivateKeyOverride);
        }
    }
}
