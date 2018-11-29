using IoTBackend.Interfaces;
using IoTBackend.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace IoTBackend_Assignment.Controllers
{
    public class DevicesDataController : ApiController
    {
        private IWeatherReport _weatherReport;

        public DevicesDataController(IWeatherReport weatherReport)
        {
            _weatherReport = weatherReport;
        }

        /// <summary>
        /// Get Reports Based On Sensors
        /// </summary>
        /// <param name="deviceId">devices Id</param>
        /// <param name="date">date for Report</param>
        /// <param name="sensorType">type of Sensors</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetReportOnSensor(string deviceId, DateTime date, string sensorType)
        {
            if (string.IsNullOrEmpty(deviceId) || date == null || string.IsNullOrEmpty(sensorType))
            {
                return BadRequest("Please Enter Valid Inputs deviceId,date,sensorType");
            }
            bool checkSensorType = Enum.GetNames(typeof(SensorType)).Any(x=>x.ToLower()== sensorType.ToLower());
            if (!checkSensorType)
            {
                return BadRequest("Please Enter Valid SensorType");
            }
            var data = _weatherReport.GetSensorDataPoints(deviceId, sensorType, date);
            if (data.SensorUnitData == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        /// <summary>
        /// Get All Sensors Report
        /// </summary>
        /// <param name="deviceId">device Id</param>
        /// <param name="date">date for Report</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetAllSensorReport(string deviceId, DateTime date)
        {
            if (string.IsNullOrEmpty(deviceId) || date == null)
            {
                return BadRequest("Please Enter Valid Inputs deviceId,date");
            }
            var data = _weatherReport.GetAllSensorsReport(deviceId, date);
            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
    }
}
