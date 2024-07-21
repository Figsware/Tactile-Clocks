using System;
using UnityEngine;

namespace Tactile.Gadgets.Clocks
{
    /// <summary>
    /// An analog clock that displays the current time using an hour, minute, and second hand.
    /// </summary>
    [AddComponentMenu("Tactile/Clocks/Analog Clock")]
    public class AnalogClock : BaseClock
    {
        /// <summary>
        /// Whether to animate the second hand smoothly.
        /// </summary>
        public bool smoothSecondHand;
        public Transform hourHand;
        public Transform minuteHand;
        public Transform secondHand;

        // Update is called once per frame
        protected override void UpdateClockDisplay()
        {
            // Determine the completion of the hour, minute, and second cycles.
            // For example, 30 seconds into the minute would be a completion of 50%
            // since 30 seconds is half of a minute. We also calculate the second
            // cycle first so that it can be added to the minute cycle, then the
            // minute cycle can be added to the hour cycle.
            float secondPercentage;
            if (smoothSecondHand)
            {
                secondPercentage = (ClockTime.Second + ClockTime.Millisecond / 1000f) / 60f;
            }
            else
            {
                secondPercentage = ClockTime.Second / 60f;
            }

            // Add each lower time unit to the higher one for smoother transitioning.
            float minutePercentage = ClockTime.Minute / 60f + (secondPercentage / 60f);
            float hourPercentage = (ClockTime.Hour % 12f) / 12f + (minutePercentage / 12f);

            if (hourHand)
                TurnAnalogHand(hourHand, hourPercentage);

            if (minuteHand)
                TurnAnalogHand(minuteHand, minutePercentage);

            if (secondHand)
                TurnAnalogHand(secondHand, secondPercentage);
        }

        /// <summary>
        /// Turns the hand of a clock around its z axis by a specified amount
        /// between 0 and 1. 0 indicates no rotation and 1 indicates a full rotation.
        /// </summary>
        /// <param name="hand">The hand to turn</param>
        /// <param name="cycleCompletion">The cycle completion between 0 and 1</param>
        private void TurnAnalogHand(Transform hand, float cycleCompletion)
        {
            hand.transform.localRotation = Quaternion.AngleAxis(360f * cycleCompletion, Vector3.back);
        }
    }
}
