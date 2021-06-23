using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public static class BatterySOCConditions
    {
        public static ParameterConditions GetSOCConditions(List<Double> SOCList)
        {
            ParameterConditions batterysoc = new ParameterConditions();
            batterysoc.MinimumValue = BatteryParametersOperations.GetMinimumParameterValue(SOCList);
            batterysoc.MaximumValue = BatteryParametersOperations.GetMaximumParameterValue(SOCList);
            batterysoc.AverageValue = BatteryParametersOperations.GetSimpleMovingAverage(SOCList);
            return batterysoc;
        }
    }
}
