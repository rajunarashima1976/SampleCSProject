using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SampleAssocaiteCode.Controllers;
using SampleAssocaiteCode.DemandService;
using System.Threading.Tasks;

namespace SampleCSProjectTest
{
    [TestFixture]
    public class DemandControllerTests
    {
        private Mock<IDemandService> _mockDemandRepository;
        private Mock<IMapper> _mockMapperRepository;
        private DemandController _controller;

        [SetUp]
        public void Setup()
        {
            _mockDemandRepository = new Mock<IDemandService>();
            _mockMapperRepository = new Mock<IMapper>();
            _controller = new DemandController(_mockDemandRepository.Object, _mockMapperRepository.Object);
        }





        [Test]
        public async Task Post_IsDemandNull_ReturnsFalse()
        {
            // Act
            _mockDemandRepository.Setup(repo => repo.Post(null))
              .ReturnsAsync(false);
            var result = await _controller.Post(null);
            

            // Assert
            Assert.Pass();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.Equals(false, result);

        }

    }
}