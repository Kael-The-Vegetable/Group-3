using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace JDoddsNAIT.Utilities
{

    /// <summary>
    /// A variable of type <typeparamref name="TValue"/> that will invoke a <see cref="UnityEvent"/> when the value is changed.
    /// </summary>
    /// <typeparam name="TValue">The type of the variable.</typeparam>
    [System.Serializable]
    public class EventVar<TValue>
    {
        [SerializeField] private TValue _value;

        public TValue Value { get => _value; set => Set(value); }

        [SerializeField] private UnityEvent<TValue> _onValueChanged;
        public UnityEvent<TValue> OnValueChanged { get => _onValueChanged; set => _onValueChanged = value; }

        public void Set(TValue newValue, bool sendCallback = true)
        {
            if (sendCallback && !_value.Equals(newValue))
            {
                OnValueChanged.Invoke(newValue);
            }
            _value = newValue;
        }

        public static implicit operator TValue(EventVar<TValue> value) => value.Value;
    }
}