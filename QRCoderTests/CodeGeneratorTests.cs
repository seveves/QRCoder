using Newtonsoft.Json;
using QRCoder;
using Shouldly;
using Xunit;

namespace QRCoderTests
{
    public class CodeGeneratorTests
    {
        [Fact]
        public void basic_code_generation_ecc_h()
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode("hello", QRCodeGenerator.ECCLevel.H);
            var test = JsonConvert.SerializeObject(qrCodeData.ModuleMatrix);
            qrCodeData.Version.ShouldBe(1);
            qrCodeData.ModuleMatrix.Count.ShouldBe(10);
        }

        [Fact]
        public void basic_code_generation_ecc_l()
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode("hello", QRCodeGenerator.ECCLevel.L);
            qrCodeData.Version.ShouldBe(10);
            qrCodeData.ModuleMatrix.Count.ShouldBe(10);
        }

        [Fact]
        public void basic_code_generation_ecc_m()
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode("hello", QRCodeGenerator.ECCLevel.M);
            qrCodeData.Version.ShouldBe(10);
            qrCodeData.ModuleMatrix.Count.ShouldBe(10);
        }

        [Fact]
        public void basic_code_generation_ecc_q()
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode("hello", QRCodeGenerator.ECCLevel.Q);
            qrCodeData.Version.ShouldBe(10);
            qrCodeData.ModuleMatrix.Count.ShouldBe(10);
        }

        [Fact]
        public void basic_code_generation_numeric()
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode("123", QRCodeGenerator.ECCLevel.H);
            qrCodeData.Version.ShouldBe(10);
            qrCodeData.ModuleMatrix.Count.ShouldBe(10);
        }

        [Fact]
        public void basic_code_generation_alphanumeric()
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode("123ABC", QRCodeGenerator.ECCLevel.H);
            qrCodeData.Version.ShouldBe(10);
            qrCodeData.ModuleMatrix.Count.ShouldBe(10);
        }

        [Fact]
        public void basic_code_generation_utf8()
        {
            var generator = new QRCodeGenerator();
            var qrCodeData = generator.CreateQrCode("hello§ßöÜä+123", QRCodeGenerator.ECCLevel.H, true);
            qrCodeData.Version.ShouldBe(10);
            qrCodeData.ModuleMatrix.Count.ShouldBe(10);
        }
    }
}
