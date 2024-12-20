using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IncreaseCount : IModifier<int>
{
    int IModifier<int>.Order => -1;

    [field: SerializeField, Tooltip("The amount by which to increase the count.")] public int Amount { get; set; }

    public IncreaseCount(int amount) => Amount = amount;

    int IModifier<int>.ApplyModifier(int baseValue, int modValue) => modValue + Amount;

    public static explicit operator IncreaseCount(int baseValue) => new(baseValue);
}
