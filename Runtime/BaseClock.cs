using System;
using UnityEngine;

namespace Tactile.Gadgets.Clocks
{
    public abstract class BaseClock : MonoBehaviour
    {
        [SerializeField] private ClockUpdateMethod updateMethod;
        [SerializeField] private string timezone;

        private DateTime _clockTime;
        public DateTime ClockTime => _clockTime;

        protected abstract void UpdateClockDisplay();


        private void FixedUpdate()
        {
            if (updateMethod == ClockUpdateMethod.FixedUpdate)
                UpdateClock();
        }

        private void Update()
        {
            if (updateMethod == ClockUpdateMethod.Update)
                UpdateClock();
        }

        private void UpdateClock()
        {
            _clockTime = DateTime.Now;
            UpdateClockDisplay();
        }

        public enum ClockUpdateMethod
        {
            Update,
            FixedUpdate,
        }
    }
}