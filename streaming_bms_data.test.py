import unittest
import streaming_bms_data

class test_streaming_bms_data(unittest.TestCase):
    def test_format_battery_parameter(self):
        bms_param = streaming_bms_data.format_battery_parameter()
        self.assertTrue(bms_param['temperature'])
        self.assertTrue(bms_param['soc'])
        self.assertTrue(bms_param['charge_rate'])
        self.assertTrue(bms_param['timestamp'])
    def test_stream_bms_reading_send(self):
        control_bms_stream.control_bms_stream('send')
        count = streaming_bms_data.stream_bms_readings(20)
        self.assertTrue(count == 2)
    def test_stream_bms_reading_stop(self):
        control_bms_stream.control_bms_stream('stop')
        count = streaming_bms_data.stream_bms_readings(2)
        self.assertTrue(count == 0)
    def test_control_bms_stream(self):
        control_bms_stream.control_bms_stream('send')
        f = open("BMS_stream_controller.txt", "r")
        self.assertEqual(f.read(), 'send' )
        f.close()
        control_bms_stream.control_bms_stream('stop')
        f = open("BMS_stream_controller.txt", "r")
        self.assertEqual(f.read(), 'stop')
        f.close()
        control_bms_stream.control_bms_stream('send')

if __name__ == '__main__':
    unittest.main()
