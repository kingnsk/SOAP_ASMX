using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutionService
{
    public interface IStatisticsService
    {
        int SuccessCount { get; set; }

        int ErrorCount { get; set; }

        int AllCounts { get; set; }
    }
}
