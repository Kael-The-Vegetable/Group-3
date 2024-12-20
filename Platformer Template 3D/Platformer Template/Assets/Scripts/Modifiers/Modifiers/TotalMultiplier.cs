using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TotalMultiplier : IModifier<float>
{
    public int Order => 100;

    [field: SerializeField] public float Multiplier { get; set; }

    public TotalMultiplier(float multiplier)
    {
        Multiplier = multiplier;
    }

    float IModifier<float>.ApplyModifier(float baseValue, float modValue)
    {
        return modValue * Multiplier;
    }
}
