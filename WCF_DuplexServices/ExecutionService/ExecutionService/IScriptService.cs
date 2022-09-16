using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExecutionService
{
    public interface IScriptService
    {
        bool Compile();
        void Run(int count);
    }
}
