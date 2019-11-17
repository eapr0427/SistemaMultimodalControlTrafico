using ControlTrafico.Data.EF.Core;
using ControlTrafico.Data.EF.Core.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;

namespace ControlTrafico.Data.UnitTests
{
    [TestFixture]
    public class FlujoRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async void CanBeSaved()
        {
            //  Triple A convention
            //Arrange
            DbContextOptions<UnitOfWork> options = new DbContextOptions<UnitOfWork>();
            UnitOfWork unitofwork = new UnitOfWork(options);
            var flujorepository = new FlujoRepository(unitofwork);

            await flujorepository.AddAsync(new Data.Domain.Entities.Flujo { fecha_hora_envio = DateTime.Now, id_ruta = 1, IdVehiculo = "1234" });
            //Act


            //Assert
            Assert.Pass();
        }
    }
}