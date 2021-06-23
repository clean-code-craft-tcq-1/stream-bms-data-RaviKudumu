using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public class BatteryParameters
    {
        public double Temperature { get; set; }
        public double StateOfCharge { get; set; }
        public double ChargeRate { get; set; }
    }
    public class BatteryParametersList
    {
        public List<Double> TemperatureList { get; set; }
        public List<Double> StateOfChargeList { get; set; }
        public List<Double> ChargeRateList { get; set; }
    }
    public struct ParameterConditions
    {
        public double MinimumValue;
        public double MaximumValue;
        public double AverageValue;
    }
}
