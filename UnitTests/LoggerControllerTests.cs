using AutoFixture;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NET6_Calculator_API.Controllers;
using NET6_Calculator_API.Data.Interfaces;
using NET6_Calculator_API.Data.Models;

namespace UnitTests
{
    public class LoggerControllerTests
    {
        private Mock<ILoggerRepository> _mockLoggerRepository;
        private Fixture _fixture;
        private LoggerController? _controller;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _mockLoggerRepository = new Mock<ILoggerRepository>();
        }

        [Test]
        public Task Post_GetLogs_ReturnOk()
        {
            var logList = _fixture.CreateMany<Log>(5).ToList();

            _mockLoggerRepository.Setup(repo => repo.GetLogs()).ReturnsAsync(logList);

            _controller = new LoggerController(_mockLoggerRepository.Object);

            var result = _controller.Get();
            var obj = result.Result as ObjectResult;

            Assert.That(obj?.StatusCode, Is.EqualTo(200));
            return Task.CompletedTask;
        }
    }
}