using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public class BMSReceiverResultLogger: ILogger
    {
        public void DisplayBatteryParamtersConditions(ParameterConditions parameterconditions, string parametername)
        {

            Console.WriteLine("Minimum {0}: {1}\nMaximum {0}: {2}\nMovingAverage: {3}", 
                parametername, parameterconditions.MinimumValue,parameterconditions.MaximumValue,parameterconditions.AverageValue);    
        }
    }
}
