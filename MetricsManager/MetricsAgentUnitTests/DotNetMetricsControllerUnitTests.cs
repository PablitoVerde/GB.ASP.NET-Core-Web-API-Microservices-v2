using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentUnitTests
{
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;
        public DotNetMetricsControllerUnitTests()
        {
            _controller = new DotNetMetricsController();
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(1);
            var toTime = TimeSpan.FromSeconds(1);

            var result = _controller.GetDotNetMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
