using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MetricsAgent.DAL;
using NLog;
using Microsoft.Extensions.Logging;

namespace MetricsAgentUnitTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController controller;
        private Mock<ICpuMetricRepository> mock;
        private Mock<ILogger<CpuMetricsController>> mockLogger;
        public CpuMetricsControllerUnitTests()
        {
            mock = new Mock<ICpuMetricRepository>();
            mockLogger = new Mock<ILogger<CpuMetricsController>>();

            controller = new CpuMetricsController(mock.Object, mockLogger.Object);
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            mock.Setup(repository => repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            var result = controller.Create(new MetricsAgent.Requests.CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            mock.Verify(repository => repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }
    }
}
