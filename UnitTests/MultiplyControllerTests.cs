using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NET6_Calculator_API.Controllers;
using NET6_Calculator_API.Data.Interfaces;

namespace UnitTests
{
    public class MultiplyControllerTests
    {
        private Mock<ILoggerRepository> _mockLoggerRepository;
        private MultiplyController? _controller;

        [SetUp]
        public void Setup()
        {
            _mockLoggerRepository = new Mock<ILoggerRepository>();
        }

        [Test]
        public Task Post_Multiply_ReturnOk()
        {
            _controller = new MultiplyController(_mockLoggerRepository.Object);

            var result = _controller.Multiply(5, 10);
            var obj = result.Result as ObjectResult;

            Assert.That(obj.Value, Is.EqualTo(50));

            return Task.CompletedTask;
        }
    }
}