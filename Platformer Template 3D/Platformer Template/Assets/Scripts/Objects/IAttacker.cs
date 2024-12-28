using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttacker
{
    public Damage Damage { get; }

    public void Attack(IDamageable damageable)
    {
        damageable.TakeDamage(Damage);
    }
}

[System.Serializable]
public class Damage
{
    public enum Type
    {
        None = 0, Electric = 1,
    }

    [field: SerializeField] public Moddable<float> Power { get; set; }
    [field: SerializeField] public Type DamageType { get; set; }
}