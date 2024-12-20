using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PercentIncrease : IModifier<float>
{
    [field: SerializeField, Tooltip("The percentage of the base value that is added to it.")]
    public float Percentage { get; set; }

    public PercentIncrease(float percentage) => Percentage = percentage;

    public PercentIncrease(int percentage) => Percentage = percentage;

    public float Add(float a, float b) => a + b;

    public float ApplyModifier(float baseValue)
    {
        return Percentage / 100f * baseValue;
    }
}
