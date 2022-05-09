using System;
using System.Collections.Generic;

namespace MetricsAgent.Responses
{
    public class AllCpuMetricResponse
    {
        public List<CpuMetricDto> Metrics { get; set; }
    }

    public class CpuMetricDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public TimeSpan Time { get; set; }
    }
}
