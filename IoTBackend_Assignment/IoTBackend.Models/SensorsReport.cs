using System.Collections.Generic;

namespace IoTBackend.Models
{
    /// <summary>
    /// Sensors Report Entity
    /// </summary>
    public class SensorsReport
    {
        /// <summary>
        /// Type of Sensors
        /// </summary>
        public string Sensortype { get; set; }

        /// <summary>
        /// Sensor Data
        /// </summary>
        public IEnumerable<int> SensorUnitData { get; set; }
    }
}
