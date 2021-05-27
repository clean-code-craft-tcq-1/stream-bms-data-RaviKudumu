
def control_bms_stream(controller):
    f = open("BMS_stream_controller.txt", "w")
    f.write(controller)
    f.close()