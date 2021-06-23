using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    interface ILogger
    {
        void DisplayBatteryParamtersConditions(ParameterConditions parameterconditions, string parametername);
    }
}
