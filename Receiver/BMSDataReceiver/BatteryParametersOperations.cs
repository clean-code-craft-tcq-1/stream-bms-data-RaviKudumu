using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public static class BatteryParametersOperations
    {
      public static double GetMaximumParameterValue(List<Double> maxbatteryparametervalue)
        {
            return maxbatteryparametervalue.Max<double>();
        }
        public static double GetMinimumParameterValue(List<Double> minbatteryparametervalue)
        {
            return minbatteryparametervalue.Min<double>();
        }
        public static double GetSimpleMovingAverage(List<Double> batteryparametermovingaverage)
        {
            batteryparametermovingaverage.Reverse();
            List<double> batteryparameterlatestreading = batteryparametermovingaverage.Take(5).ToList();
            return batteryparameterlatestreading.Average();
        }
    }
}
