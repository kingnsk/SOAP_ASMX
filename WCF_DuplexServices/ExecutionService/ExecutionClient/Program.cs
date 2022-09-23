using ExecutionClient.ExecutionServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ExecutionClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InstanceContext instanceContext = new InstanceContext(new CallbackHandler());
            ExecutionServiceClient client = new ExecutionServiceClient(instanceContext);

            client.UpdateAndCompileScript(@"C:\scripts\Sample.script");
            client.RunScript();
            Console.WriteLine("Please, press Enter to Exit..");
            Console.ReadKey();

            client.Close();
        }
    }
}
