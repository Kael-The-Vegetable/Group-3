using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierTest : MonoBehaviour
{
    [SerializeField] private Moddable<float> _modifiableValue;
    [SerializeField, ReadOnly] private float _modValue;
    [Space]
    [SerializeField] private List<float> _modifiers;

    private void OnValidate()
    {
        _modifiableValue.Modifiers.Clear();

        foreach (var modifier in _modifiers)
        {
            _modifiableValue.Modifiers.Add(new PercentIncrease(modifier));
        }

        _modValue = _modifiableValue.ModifiedValue;
    }
}
