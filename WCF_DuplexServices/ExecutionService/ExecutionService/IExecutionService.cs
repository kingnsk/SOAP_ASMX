using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ExecutionService
{
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples",SessionMode = SessionMode.Required, CallbackContract = typeof(IExecuteServiceCallback))]
    public interface IExecutionService
    {
        [OperationContract]
        void RunScript();

        [OperationContract]
        void UpdateAndCompileScript(string fileName);
    }
}
