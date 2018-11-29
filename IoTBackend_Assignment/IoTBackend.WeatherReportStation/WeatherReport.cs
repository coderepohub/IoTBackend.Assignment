using IoTBackend.Interfaces;
using IoTBackend.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace IoTBackend.WeatherReportStation
{
    public class WeatherReport : IWeatherReport
    {
        private IBlobFramework _blobFramework;
        string blobUrl = ConfigurationManager.AppSettings["blobUrl"].ToString();
        string sasToken = ConfigurationManager.AppSettings["sasToken"].ToString();

        #region ctor
        public WeatherReport(IBlobFramework blobFramework)
        {
            _blobFramework = blobFramework;
        }
        #endregion

        /// <summary>
        /// Get Report for All Sensors
        /// </summary>
        /// <param name="deviceId">device ID</param>
        /// <param name="dateTime">datetime for the report</param>
        /// <returns></returns>
        public IEnumerable<SensorsReport> GetAllSensorsReport(string deviceId, DateTime dateTime)
        {
            var sensors = Enum.GetNames(typeof(SensorType));
            var sensorsReport = new List<SensorsReport>();
            foreach(var sensor in sensors)
            {
                sensorsReport.Add(GetSensorDataPoints(deviceId, sensor.ToLower(), dateTime));
            }

            return sensorsReport;
        }

        /// <summary>
        /// Get Data Based on Senosrs
        /// </summary>
        /// <param name="deviceId">device Id</param>
        /// <param name="sensorType">type of sensors</param>
        /// <param name="dateTime"> datetime for report</param>
        /// <returns></returns>
        public SensorsReport GetSensorDataPoints(string deviceId, string sensorType, DateTime dateTime)
        {
            return GetSensorReport(deviceId, sensorType, dateTime);
        }

        /// <summary>
        /// Get Report based on Sensors
        /// </summary>
        /// <param name="deviceId">device id</param>
        /// <param name="sensorType">type of sensors</param>
        /// <param name="dateTime">time for report</param>
        /// <returns></returns>
        private SensorsReport GetSensorReport(string deviceId, string sensorType, DateTime dateTime)
        {
            try
            {
                string formatUrl = string.Format("{0}/{1}/{2}/{3}.csv?{4}", blobUrl, deviceId, sensorType, dateTime.ToString("yyyy-MM-dd"), sasToken);
                var getContentFromBlob = _blobFramework.GetBlobContent(formatUrl);
                var rowsList = getContentFromBlob.Split('\n');
                List<CSVData> csvDataList = new List<CSVData>();
                foreach (var row in rowsList)
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        var columnItem = row.Split(',');
                        csvDataList.Add(new CSVData() { Date = Convert.ToDateTime(columnItem[0]), SensorData = Convert.ToInt32(columnItem[1]), Unit = Convert.ToInt32(columnItem[2]) });
                    }
                }
                var listOfData = (from dt in csvDataList
                                  where dt.Date.ToString("yyyy-MM-dd") == dateTime.Date.ToString("yyyy-MM-dd") && dt.Unit == 1
                                  select dt.SensorData).ToList();
                return new SensorsReport() { Sensortype = sensorType, SensorUnitData = listOfData };
            }
            catch (Exception)
            {
                return new SensorsReport() { Sensortype = sensorType, SensorUnitData = null };
            }
        }
    }
}
