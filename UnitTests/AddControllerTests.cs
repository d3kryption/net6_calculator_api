using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NET6_Calculator_API.Controllers;
using NET6_Calculator_API.Data.Interfaces;

namespace UnitTests
{
    public class AddControllerTests
    {
        private Mock<ILoggerRepository> _mockLoggerRepository;
        private AddController? _controller;

        [SetUp]
        public void Setup()
        {
            _mockLoggerRepository = new Mock<ILoggerRepository>();
        }

        [Test]
        public Task Post_Add_ReturnOk()
        {
            _controller = new AddController(_mockLoggerRepository.Object);

            var result = _controller.Add(5, 10);
            var obj = result.Result as ObjectResult;

            Assert.That(obj.Value, Is.EqualTo(15));

            return Task.CompletedTask;
        }
    }
}