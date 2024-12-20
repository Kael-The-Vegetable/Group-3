using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModifierTest : MonoBehaviour
{
    [SerializeField] private Moddable<float> _value;
    [SerializeField, ReadOnly] private float _modValue;

    private void OnValidate()
    {
        _modValue = _value.ModifiedValue;
    }
}
