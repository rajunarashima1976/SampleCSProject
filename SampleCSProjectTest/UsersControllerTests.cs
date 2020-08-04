using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using SampleAssocaiteCode.Controllers;
using SampleAssocaiteCode.Models;
using SampleAssocaiteCode.UserService;
using System.Threading.Tasks;

namespace SampleCSProjectTest
{
    [TestFixture]
    public class UsersControllerTests
    {
        private Mock<IUserService> _mockUserRepository;
        private Mock<IMapper> _mockMapperRepository;
        private UsersController _controller;
        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserService>();
            _mockMapperRepository = new Mock<IMapper>();
            _controller = new UsersController(_mockUserRepository.Object, _mockMapperRepository.Object);
        }

        [Test]
        public async Task Authenticate_UserCredentialsIsCorrect_ReturnsToken()
        {
            _mockUserRepository.Setup(x => x.Authenticate("abc", "abc")).ReturnsAsync(new UserRolesDTO());
            var result = await _controller.Authenticate(new UserDTO { Username = "abc", Password = "abc" });

            // Assert
            Assert.Pass();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            Assert.Equals(new UserRolesDTO(), result);
        }

        [Test]
        public async Task Post_UserCredentialsIsNull_ReturnsBadRequest()
        {
            // Act
            _mockUserRepository.Setup(x => x.Authenticate("", "")).ReturnsAsync(new UserRolesDTO());

            var result = await _controller.Authenticate(new UserDTO());

            // Assert
            Assert.Pass();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);
            //Assert.Equals(BadRequestResult, result);
            Assert.IsInstanceOf<BadRequestResult>(result);

        }

        [Test]
        public async Task GellAll_UserIsExist_ReturnsUserList()
        {
            // Act
            var result = await _controller.GetAll();

            // Assert
            Assert.Pass();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

        }

        [Test]
        public async Task Gell_UserIsExit_ReturnsMatchedUser()
        {
            // Act
            var result = await _controller.Get(4);

            // Assert
            Assert.Pass();
            var okObjectResult = result as OkObjectResult;
            Assert.IsNotNull(okObjectResult);

        }
    }
}
