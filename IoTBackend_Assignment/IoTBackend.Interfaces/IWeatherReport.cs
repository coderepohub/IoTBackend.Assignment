using IoTBackend.Models;
using System;
using System.Collections.Generic;

namespace IoTBackend.Interfaces
{
    public interface IWeatherReport
    {
        /// <summary>
        /// Get Data Points based on Sesnor Types
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="sensorType"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        SensorsReport GetSensorDataPoints(string deviceId, string sensorType, DateTime dateTime);

        /// <summary>
        /// Get Report for All Sensor Types
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        IEnumerable<SensorsReport> GetAllSensorsReport(string deviceId, DateTime dateTime);
        

    }
}
