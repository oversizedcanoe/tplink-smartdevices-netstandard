﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPLinkSmartDevices.Data
{
    /// <summary>
    /// Encapsulates JSON data structure for current energy use as metered by the HS110 Smart Energy Meter.
    /// </summary>
    public class PowerData
    {
        private readonly dynamic _powerData;

        public PowerData(dynamic powerData)
        {
            _powerData = powerData;
        }

        /// <summary>
        /// Currently measured voltage in volts.
        /// </summary>
        public double Voltage => _powerData.voltage_mv / 1000.0d;

        /// <summary>
        /// Currently measured current in amperes.
        /// </summary>
        public double Amperage => _powerData.current_ma / 1000.0d;

        /// <summary>
        /// Currently measured power in watts.
        /// </summary>
        public double Power => _powerData.power_mw / 1000.0d;

        /// <summary>
        /// Total power consumption in kilowatthours. What does total mean here? In which timeframe?
        /// </summary>
        public double Total => _powerData.total_wh / 1000.0d;

        public int ErrorCode => _powerData.err_code;

        public override string ToString()
        {
            return $"{Voltage/1000.0d:0.0} Volt, {Amperage/1000.0d:0.00} Ampere, {Power/1000.0:0.00} Watt";
        }
    }
}
