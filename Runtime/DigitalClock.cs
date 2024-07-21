using System;
using UnityEngine;
using UnityEngine.Events;

namespace Tactile.Gadgets.Clocks
{
    [AddComponentMenu("Tactile/Clocks/Digital Clock")]
    [ExecuteAlways]
    public class DigitalClock : BaseClock
    {
        /// <summary>
        /// The format to display the time.
        /// </summary>
        public string timeFormat = "h:mm tt";
        
        /// <summary>
        /// An event that is triggered when there is new clock text.
        /// </summary>
        public UnityEvent<string> onNewClockText;
        
        protected override void UpdateClockDisplay()
        {
            var timeStr = ClockTime.ToString(timeFormat);
            onNewClockText.Invoke(timeStr);
        }
    }
}