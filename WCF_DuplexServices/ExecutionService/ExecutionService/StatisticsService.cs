using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExecutionService
{
    public class StatisticsService : IStatisticsService
    {
        public int SuccessCount { get; set; }
        public int ErrorCount { get; set; }
        public int AllCounts { get; set; }
    }
}