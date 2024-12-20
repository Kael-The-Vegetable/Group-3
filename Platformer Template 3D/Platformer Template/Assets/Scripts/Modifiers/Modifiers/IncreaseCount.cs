using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class IncreaseCount : IModifier<int>
{
    [field: SerializeField, Tooltip("The amount by which to increse the count.")] public int Amount { get; set; }

    public IncreaseCount(int amount) => Amount = amount;

    public int Add(int a, int b) => a + b;

    public int ApplyModifier(int baseValue) => baseValue + Amount;
}
