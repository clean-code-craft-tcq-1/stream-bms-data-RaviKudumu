using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public class FakeReceiverResultLogger : ILogger
    {
        public bool isDisplayResultFunctionCalledAtleastOnce = false;
        public void DisplayBatteryParamtersConditions(ParameterConditions parameterconditions, string parametername)
        {
            this.isDisplayResultFunctionCalledAtleastOnce = true;
        }
    }
}
