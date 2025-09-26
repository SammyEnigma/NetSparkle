using CommandLine;
using NetSparkleUpdater.AppCastGenerator;
using Xunit;

namespace NetSparkleUnitTests;

public class OptionsTests
{
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
    }
}