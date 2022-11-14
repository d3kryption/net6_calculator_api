using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NET6_Calculator_API.Controllers;
using NET6_Calculator_API.Data.Interfaces;

namespace UnitTests
{
    public class SubtractControllerTests
    {
        private Mock<ILoggerRepository> _mockLoggerRepository;
        private SubtractController? _controller;

        [SetUp]
        public void Setup()
        {
            _mockLoggerRepository = new Mock<ILoggerRepository>();
        }

        [Test]
        public Task Post_Subtract_ReturnOk()
        {
            _controller = new SubtractController(_mockLoggerRepository.Object);

            var result = _controller.Subtract(10, 5);
            var obj = result.Result as ObjectResult;

            Assert.That(obj.Value, Is.EqualTo(5));

            return Task.CompletedTask;
        }
    }
}