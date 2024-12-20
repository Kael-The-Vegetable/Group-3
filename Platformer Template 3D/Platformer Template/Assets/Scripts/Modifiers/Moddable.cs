using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Moddable<TValue>
{
    [SerializeField] private TValue _baseValue;

    public TValue BaseValue { get => _baseValue; set => _baseValue = value; }
    public ModifierList<TValue> Modifiers { get; set; }

    public TValue ModifiedValue => Modifiers.ApplyModifiers(BaseValue);

    public Moddable() => Modifiers = new();
}
