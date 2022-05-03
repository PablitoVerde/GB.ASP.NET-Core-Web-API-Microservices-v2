using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentUnitTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _controller;
        public CpuMetricsControllerUnitTests()
        {
            _controller = new CpuMetricsController();
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(1);
            var toTime = TimeSpan.FromSeconds(1);

            var result = _controller.GetCpuMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
