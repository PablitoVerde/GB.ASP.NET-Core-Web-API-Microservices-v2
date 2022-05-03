using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentUnitTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;
        public RamMetricsControllerUnitTests()
        {
            _controller = new RamMetricsController();
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(1);
            var toTime = TimeSpan.FromSeconds(1);

            var result = _controller.GetRamMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
