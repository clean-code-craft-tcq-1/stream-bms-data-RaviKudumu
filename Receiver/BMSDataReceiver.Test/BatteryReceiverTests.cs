using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BMSDataReceiver;
using System.Collections.Generic;

namespace BMSDataReceiver.Test
{
    [TestClass]
    public class BatteryReceiverTests
    {
        [TestMethod]
        public void WhenReadingInputIsNull_ThenGetBatteryParamtersMeasuresReturnsNull()
        {
            BatteryParameterDataFromInput testbatteryinput = new BatteryParameterDataFromInput();
            Assert.IsNull(testbatteryinput.GetBatteryParamtersMeasures(null));
        }
        [TestMethod]
        public void WhenReadingInputIsNotNull_ThenGetBatteryParamtersMeasuresReturnsNotNull()
        {
            BatteryParameterDataFromInput testbatteryinput = new BatteryParameterDataFromInput();
            Assert.IsNotNull(testbatteryinput.GetBatteryParamtersMeasures("{'temperature': 22, 'soc': 23, 'charge_rate': 0.01, 'timestamp': '23/06/2021 15:32:43'}"));
        }
        [TestMethod]
        public void WhenParameterListIsEmpty_ThenInitializeBatteryParameterListsReturnsNull()
        {
            List<BatteryParameters> testbatteryparameterlist = new List<BatteryParameters>{ };
            BatteryParameterDataFromInput testinputparameterlist = new BatteryParameterDataFromInput();
            Assert.IsNull(testinputparameterlist.InitializeBatteryParameterLists(testbatteryparameterlist));
        }
        [TestMethod]
        public void WhenParameterListIsNotEmpty_ThenInitializeBatteryParameterListsReturnsNotNull()
        {
            List<BatteryParameters> testbatteryparameterlist = new List<BatteryParameters> { };
            BatteryParameters testparameters = new BatteryParameters();
            testparameters.Temperature = 23; testparameters.StateOfCharge = 44; testparameters.ChargeRate = 0.8;
            testbatteryparameterlist.Add(testparameters);
            BatteryParameterDataFromInput testinputparameterlist = new BatteryParameterDataFromInput();
            Assert.IsNotNull(testinputparameterlist.InitializeBatteryParameterLists(testbatteryparameterlist));
        }
        [TestMethod]
        public void WhenParameterListIsInput_ThenGetMaximumParameterValueReturnsMaxValue()
        {
            double maxparametervalue = BatteryParametersOperations.GetMaximumParameterValue(new List<Double> { 12, 43, 56, 3 });
            Assert.IsTrue(!Double.IsNaN(maxparametervalue));
        }
        [TestMethod]
        public void WhenParameterListIsInput_ThenGetMinimumParameterValueReturnsMinValue()
        {
            double minparametervalue = BatteryParametersOperations.GetMinimumParameterValue(new List<Double> { 12, 43, 56, 3 });
            Assert.IsTrue(!Double.IsNaN(minparametervalue));
        }
        [TestMethod]
        public void WhenParameterListIsInput_ThenGetSimpleMovingAverageReturnsAverageValue()
        {
            double avgparametervalue = BatteryParametersOperations.GetSimpleMovingAverage(new List<Double> { 12, 43, 56, 3 });
            Assert.IsTrue(!Double.IsNaN(avgparametervalue));
        }
        [TestMethod]
        public void WhenTemperatureListIsInput_ThenGetTemperatureConditionsReturnsNotNull()
        {
            Assert.IsNotNull(BatteryTemperatureConditions.GetTemperatureConditions(new List<Double> { 12, 43, 56, 3 }));
        }
        [TestMethod]
        public void WhenSOCListIsInput_ThenGetSOCConditionsReturnsNotNull()
        {
            Assert.IsNotNull(BatterySOCConditions.GetSOCConditions(new List<Double> { 2, 14, 26, 23 }));
        }
        [TestMethod]
        public void WhenChargeRateListIsInput_ThenGetChargeRateConditionsReturnsNotNull()
        {
            Assert.IsNotNull(BatteryChargeRateConditions.GetChargeRateConditions(new List<Double> { 1.2, 4.3, 5.6, 0.3 }));
        }
        [TestMethod]
        public void WhenParameterResultIsInput_ThenDisplayBatteryParamtersConditionsCalledIsTrue()
        {
            FakeReceiverResultLogger testdisplayreceiverresult = new FakeReceiverResultLogger();
            testdisplayreceiverresult.DisplayBatteryParamtersConditions(BatteryTemperatureConditions.GetTemperatureConditions(new List<Double> { 12, 43, 56, 3 }), "Temperature");
            Assert.IsTrue(testdisplayreceiverresult.isDisplayResultFunctionCalledAtleastOnce);
        }
    }
}
