using System;
using Xunit;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace MetricsAgentUnitTests
{
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController _controller;
        public NetworkMetricsControllerUnitTests()
        {
            _controller = new NetworkMetricsController();
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(1);
            var toTime = TimeSpan.FromSeconds(1);

            var result = _controller.GetNetworkMetrics(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}
