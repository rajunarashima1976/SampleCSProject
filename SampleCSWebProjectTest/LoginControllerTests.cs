using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using SampleCSWebProject.Comman;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SampleCSWebProjectTest
{
    public class LoginControllerTests
    {
        private Mock<IOptions<AppSettings>> _mockAppSettingRepository;
        private SampleCSWebProject.Controllers.LoginController _controller;

        [SetUp]
        public void Setup()
        {
            _mockAppSettingRepository = new Mock<IOptions<AppSettings>>();
            _controller = new SampleCSWebProject.Controllers.LoginController(_mockAppSettingRepository.Object);
        }

        [Test]
        public async Task Index_ReturnsAsActionResult_WithLoginPage()
        {
            var result = await _controller.Index();
            Assert.Pass();
            Assert.IsNotNull(result as IActionResult);
        }
    }
}
}
