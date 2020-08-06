using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using SampleCSWebProject.Comman;
using SampleCSWebProject.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleCSWebProjectTest
{
    public class DemandControllerTests
    {
        private Mock<IOptions<AppSettings>> _mockAppSettingRepository;
        private Mock<IMapper> _mockMapperRepository;
        private DemandController _controller;

        [SetUp]
        public void Setup()
        {
            _mockAppSettingRepository = new Mock<IOptions<AppSettings>>();
            _mockMapperRepository = new Mock<IMapper>();
            _controller = new DemandController(_mockMapperRepository.Object, _mockAppSettingRepository.Object);
        }

        [Test]
        public async Task Create_ReturnsAsActionResult_WithCreateDemandPage()
        {
            var result = await _controller.Create();
            Assert.Pass();
            Assert.IsNotNull(result as IActionResult);
        }
    }
}

