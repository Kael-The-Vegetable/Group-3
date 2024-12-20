using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PercentBonus : IModifier<float>, IModifier<int>
{
    int IModifier<float>.Order => 0;
    int IModifier<int>.Order => 0;

    [field: SerializeField, Tooltip("The percentage of the base value that is added to it.")]
    public Moddable<float> Percentage { get; set; }

    public PercentBonus(float percentage) => Percentage.BaseValue = percentage;

    float IModifier<float>.ApplyModifier(float baseValue, float modValue)
    {
        return modValue + Percentage.ModifiedValue / 100f * baseValue;
    }

    int IModifier<int>.ApplyModifier(int baseValue, int modValue)
    {
        return (int)(modValue + Percentage.ModifiedValue / 100f * baseValue);
    }

    public static explicit operator PercentBonus(float baseValue) => new(baseValue);
}
