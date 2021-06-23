using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public class BatteryParameterDataFromInput
    {
        public BatteryParameters GetBatteryParamtersMeasures(string readingsInput)
        {
            if (readingsInput != null)
            {
                var batteryReadings = Regex.Matches(readingsInput, @"\d+").Cast<Match>().Select(x => double.Parse(x.Value)).ToArray();
                BatteryParameters batteryparameters = new BatteryParameters();
                if (batteryReadings != null && batteryReadings.Length >= 4)
                {
                    batteryparameters.Temperature = batteryReadings[0];
                    batteryparameters.StateOfCharge = batteryReadings[1];
                    batteryparameters.ChargeRate = Convert.ToDouble(batteryReadings[2].ToString() + "." + batteryReadings[3].ToString());
                }
                return batteryparameters;
            }
            return null;
        }
        public BatteryParametersList InitializeBatteryParameterLists(List<BatteryParameters> batteryparameterlist)
        {
            if (batteryparameterlist.Any()) 
            {
                List<Double> TemperatureList, StateOfChargeList, ChargeRateList;
                TemperatureList = batteryparameterlist.Select(list => list.Temperature).ToList();
                StateOfChargeList = batteryparameterlist.Select(list => list.StateOfCharge).ToList();
                ChargeRateList = batteryparameterlist.Select(list => list.ChargeRate).ToList();

                return new BatteryParametersList { TemperatureList = TemperatureList, StateOfChargeList = StateOfChargeList, ChargeRateList = ChargeRateList };
            }
            return null;
        }
    }
}
