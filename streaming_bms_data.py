import random

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
    return format_battery_param

def send_to_console():
    while(True):
        print(format_battery_parameter())
        stop_sending = 'X'
        if stop_sending == 'X':
            break
