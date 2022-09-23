using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExecutionService
{
    public class SettingsService : ISettingsService
    {
        public string FileName { get; set; }
    }
}