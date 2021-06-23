using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public static class BatteryChargeRateConditions
    {
        public static ParameterConditions GetChargeRateConditions(List<Double> ChargeRateList)
        {
            ParameterConditions batterychargerate = new ParameterConditions();
            batterychargerate.MinimumValue = BatteryParametersOperations.GetMinimumParameterValue(ChargeRateList);
            batterychargerate.MaximumValue = BatteryParametersOperations.GetMaximumParameterValue(ChargeRateList);
            batterychargerate.AverageValue = BatteryParametersOperations.GetSimpleMovingAverage(ChargeRateList);
            return batterychargerate;
        }
    }
}
