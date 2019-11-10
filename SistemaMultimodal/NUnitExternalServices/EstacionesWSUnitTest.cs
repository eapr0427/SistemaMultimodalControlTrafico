using ControlTrafico.Application.DTO;
using ControlTrafico.ExternalServices.Services;
using NUnit.Framework;

namespace NUnitExternalServices
{
    [TestFixture]
    public class EstacionesWSUnitTest : BaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestLoadEstaciones()
        {
            ResponseDto<EstacionesRootResponseDto> estaciones = null;
            try
            {
                IApiService instance = CreateInstance();
               estaciones = instance.GetEstaciones().Result;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            Assert.IsNotNull(estaciones);
        }

        protected override IApiService CreateInstance()
        {
            return new ApiService();
        }
    }
}