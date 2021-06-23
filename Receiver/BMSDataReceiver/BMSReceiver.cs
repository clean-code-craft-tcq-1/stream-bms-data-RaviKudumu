using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BMSDataReceiver
{
    public class BMSReceiver
    {
        public static void Main(string[] args)
        {
            string bmssenderinput;
            int bmssenderinputcount = 0;
            List<BatteryParameters> batterymeasures = new List<BatteryParameters>();
            BatteryParameterDataFromInput batteryparmeter = new BatteryParameterDataFromInput();
            BatteryParametersList batteryparameterlists = new BatteryParametersList();
            ILogger batteryparameterconditions = new BMSReceiverResultLogger();
            while ((bmssenderinput = Console.ReadLine()) != null)
            {
                batterymeasures.Add(batteryparmeter.GetBatteryParamtersMeasures(bmssenderinput));
                bmssenderinputcount++;

                if (bmssenderinputcount == 15)
                    break;
            }
           
            batteryparameterlists  = batteryparmeter.InitializeBatteryParameterLists(batterymeasures);
            batteryparameterconditions.DisplayBatteryParamtersConditions(BatteryTemperatureConditions.GetTemperatureConditions(batteryparameterlists.TemperatureList),"Temperature");
            batteryparameterconditions.DisplayBatteryParamtersConditions(BatterySOCConditions.GetSOCConditions(batteryparameterlists.StateOfChargeList), "StateOfCharge");
            batteryparameterconditions.DisplayBatteryParamtersConditions(BatteryChargeRateConditions.GetChargeRateConditions(batteryparameterlists.ChargeRateList), "ChargeRate");
        }
    }
}
