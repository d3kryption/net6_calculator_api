using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NET6_Calculator_API.Controllers;
using NET6_Calculator_API.Data.Interfaces;

namespace UnitTests
{
    public class DivideControllerTests
    {
        private Mock<ILoggerRepository> _mockLoggerRepository;
        private DivideController? _controller;

        [SetUp]
        public void Setup()
        {
            _mockLoggerRepository = new Mock<ILoggerRepository>();
        }

        [Test]
        public Task Post_Divide_ReturnOk()
        {
            _controller = new DivideController(_mockLoggerRepository.Object);

            var result = _controller.Divide(10, 5);
            var obj = result.Result as ObjectResult;

            Assert.That(obj.Value, Is.EqualTo(2));

            return Task.CompletedTask;
        }

        [Test]
        public Task Post_Divide_ThrowException()
        {
            _controller = new DivideController(_mockLoggerRepository.Object);

            var result = _controller.Divide(0, 5);
            var obj = result.Result as ObjectResult;

            Assert.That(obj?.StatusCode, Is.EqualTo(400));

            return Task.CompletedTask;
        }
    }
}