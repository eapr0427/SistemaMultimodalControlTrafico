using ControlTrafico.Application.DTO;
using ControlTrafico.Application.DTO.Vehiculo;
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
                estaciones = instance.GetEstacionesAsync().Result;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            Assert.IsNotNull(estaciones);
        }

        [Test]
        public void TestConsultarVehiculoDisponible()
        {
            ResponseDto<VehiculoDto> vehiculo = null;
            try
            {
                IApiService instance = CreateInstance();
                vehiculo = instance.GetVehiculoDisponiblesync();
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            Assert.IsNotNull(vehiculo);
        }

        protected override IApiService CreateInstance()
        {
            return new ApiService();
        }
    }
}