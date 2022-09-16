using ExecutionClient.ExecutionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutionClient
{
    internal class CallbackHandler : IExecutionServiceCallback
    {
        public void UpdateStatistics(StatisticsService statistics)
        {
            Console.Clear();
            Console.WriteLine("Обновление по статистике выполнения скрипта:");
            Console.WriteLine($"Всего         итераций: {statistics.AllCounts}");
            Console.WriteLine($"Успешных      итераций: {statistics.SuccessCount}");
            Console.WriteLine($"Ошибочных     итераций: {statistics.ErrorCount}");
        }
    }
}
