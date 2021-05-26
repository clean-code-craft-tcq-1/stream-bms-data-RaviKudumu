import unittest
import streaming_bms_data
class test_streaming_bms_data(unittest.TestCase):
    def test_format_battery_parameter(self):
        bms_param = streaming_bms_data.format_battery_parameter()
        self.assertTrue(bms_param['temperature'])
        self.assertTrue(bms_param['soc'])
        self.assertTrue(bms_param['charge_rate'])

if __name__ == '__main__':
    unittest.main()
