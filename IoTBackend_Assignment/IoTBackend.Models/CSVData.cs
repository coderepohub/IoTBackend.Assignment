using System;

namespace IoTBackend.Models
{
    /// <summary>
    /// Class to reperesent the CSV formatted data
    /// </summary>
    public class CSVData
    {
        /// <summary>
        /// Represent Date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Represent Sensor Data
        /// </summary>
        public int SensorData { get; set; }

        /// <summary>
        /// Represent Units
        /// </summary>
        public int Unit { get; set; }
    }
}














