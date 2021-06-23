using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public static class BatteryTemperatureConditions
    {
       public static ParameterConditions GetTemperatureConditions(List<Double> TemperatureList)
        {
            ParameterConditions batterytemperature = new ParameterConditions();
            batterytemperature.MinimumValue = BatteryParametersOperations.GetMinimumParameterValue(TemperatureList);
            batterytemperature.MaximumValue = BatteryParametersOperations.GetMaximumParameterValue(TemperatureList);
            batterytemperature.AverageValue = BatteryParametersOperations.GetSimpleMovingAverage(TemperatureList);
            return batterytemperature;
        }
    }
}
