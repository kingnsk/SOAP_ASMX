using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ExecutionService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ExecutionService : IExecutionService
    {
        private readonly IScriptService _scriptService;
        private readonly IStatisticsService _statisticsService;
        private readonly ISettingsService _settingsService;

        public ExecutionService()
        {
            _statisticsService = new StatisticsService();
            _settingsService = new SettingsService();
            _scriptService = new ScriptService(_statisticsService, _settingsService, Callback);
        }

        public void RunScript()
        {
            _scriptService.Run(10);
        }

        public void UpdateAndCompileScript(string fileName)
        {
            _settingsService.FileName = fileName;
            _scriptService.Compile();
        }

        IExecuteServiceCallback Callback
        {
            get
            {
                if (OperationContext.Current != null)
                    return OperationContext.Current.GetCallbackChannel<IExecuteServiceCallback>();
                else
                    return null;
            }
        }
    }
}
