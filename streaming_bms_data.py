import random
import time,datetime

batter_limits = {"temperature": [0,45,"temperature"],
                    "soc": [20,80,"soc"],
                    "charge_rate": [0, 0.8,"charge_rate"]}

def format_battery_parameter():
    format_battery_param = {}
    temperature_limits = batter_limits['temperature']
    format_battery_param["temperature"] = random.randint(temperature_limits[0],
                                                         temperature_limits[1])
    soc_limits = batter_limits['soc']
    format_battery_param["soc"] = random.randint(soc_limits[0],
                                                         soc_limits[1])
    charge_rate_limits = batter_limits['charge_rate']
    format_battery_param["charge_rate"] = round(random.uniform(charge_rate_limits[0],
                                                         charge_rate_limits[1]), 2)
    format_battery_param['timestamp'] = datetime.datetime.now().strftime("%d/%m/%Y %H:%M:%S")
    return format_battery_param

def stream_bms_readings(max_count):
    bms_records_count = 0
    count = 0
    while(count < max_count):
        f = open("BMS_stream_controller.txt", "r")
        if f.read() == 'send':
            f.close()
            print(format_battery_parameter())
            bms_records_count += 1
        else:
            f.close()
            break
        time.sleep(1/5)
        count += 1
    return bms_records_count
  
stream_bms_readings(5000)
