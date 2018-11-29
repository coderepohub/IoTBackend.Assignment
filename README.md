# IoTBackend.Assignment
Solution for IoTBackend Problem Statement

## Sample Request to test the Application

Below are the sample request to test the Application

1 - Collect all of the measurements for one day, one sensor type, and one unit , which returns data unit for particular Sensor
    a. [GET]
       http://localhost:62143/api/DevicesData/GetDataOnSensor?deviceId=dockan&date=2018-11-15&sensorType=humidity
    b. [GET]
       http://localhost:62143/api/DevicesData/GetDataOnSensor?deviceId=dockan&date=2018-11-15&sensorType=temperature
       
2 - Collect all data points for one unit and one day, which returns temperature, humidity, and rainfall for the day.
    [GET]
    http://localhost:62143/api/DevicesData/GetAllSensorReport?deviceId=dockan&date=2018-11-15
    
    
## Enhancements

There are few enhancements that has to be made in the application like, to get all the reports for sensors have to unzip and extract all the historical information .
       
    
