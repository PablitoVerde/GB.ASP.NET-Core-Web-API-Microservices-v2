using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentUnitTests
{
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController _controller;
        public HddMetricsControllerUnitTests()
        {
            _controller = new HddMetricsController();
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(1);
            var toTime = TimeSpan.FromSeconds(1);

            var result = _controller.GetHddMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
