using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JDoddsNAIT.Timers
{
    public class Timer : MonoBehaviour
    {
        private enum TimerUnits { Seconds, SecondsUnscaled, Frames }

        #region Private Fields
        private float _startTime, _elapsedTime;
        private bool _paused = false;
        #endregion

        #region Serialized Fields
        [SerializeField, Tooltip("The timer's max duration.")]
        [Min(0)] private float _duration;
        [SerializeField, Tooltip("Represents how the timer keeps track of time.")]
        private TimerUnits _timingMethod;
        [Space]
        [SerializeField]
        private UnityEvent _alarm;
        [Space]
        [SerializeField, Tooltip("The timer will start when this script is loaded.")]
        private bool _startOnAwake;
        [SerializeField, Tooltip("The timer will start again after finishing.")]
        private bool _repeat;
        [SerializeField, Tooltip("The Elapsed variable will be initialized to this value.")]
        private bool _startElapsed;
        #endregion

        private float _endTime => _startTime + Duration;

        private float CurrentTime => _timingMethod switch
        {
            TimerUnits.Seconds => Time.time,
            TimerUnits.SecondsUnscaled => Time.unscaledTime,
            TimerUnits.Frames => Time.frameCount,
            _ => Time.time,
        };

        /// <summary>
        /// Whether the timer is currently paused.
        /// </summary>
        public bool Paused { get => _paused; set => _paused = value; }

        /// <summary>
        /// The amount of time that has passed since the timer started. (Read Only)
        /// </summary>
        public float TimeElapsed { get => _elapsedTime - _startTime; private set => _elapsedTime = value + _startTime; }

        /// <summary>
        /// Is true after the timer is complete. If <see cref="_startElapsed"/> is true, is the inverse
        /// </summary>
        public bool Elapsed { get; private set; }

        /// <summary>
        /// The timer's max duration.
        /// </summary>
        public float Duration { get => _duration; set => _duration = value; }

        /// <summary>
        /// Invoked whenever the timer ends.
        /// </summary>
        public UnityEvent Alarm => _alarm;

        private void Awake()
        {
            Elapsed = _startElapsed;

            if (_startOnAwake)
            {
                StartTimer();
            }
        }

        /// <summary>
        /// Stops the current timer and starts a new one.
        /// </summary>
        public void StartTimer()
        {
            StopTimer();
            StartTimer();
        }

        /// <summary>
        /// Stops the current timer.
        /// </summary>
        public void StopTimer()
        {
            StopCoroutine(TimerCount());
        }

        private IEnumerator TimerCount()
        {
            _startTime = CurrentTime;
            Paused = false;

            yield return new WaitUntil(IsElapsed);

            _elapsedTime = _endTime;
            Alarm.Invoke();

            if (_repeat)
            {
                StartTimer();
            }
        }

        private bool IsElapsed()
        {
            if (Paused)
            {
                _startTime = CurrentTime - TimeElapsed;
            }
            else
            {
                _elapsedTime = CurrentTime;
            }

            Elapsed = TimeElapsed > Duration;

            return Elapsed;
        }
    }
}