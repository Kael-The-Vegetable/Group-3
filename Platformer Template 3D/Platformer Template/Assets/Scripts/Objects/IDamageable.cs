using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public interface IDamageable
{
    public Moddable<float> MaxHealth { get; }
    public float Health { get; set; }
    public DamageResistances Resistances { get; }

    public void TakeDamage(Damage damage)
    {
        Health -= Resistances.CalculateDamage(damage);

        if (Health <= 0)
        {
            Destroy();
        }
    }

    public void Destroy();
}

[System.Serializable]
public class DamageResistances
{
    [SerializeField] private List<DamageResistance> _resistances;

    public List<DamageResistance> Resistances { get => _resistances; set => _resistances = value; }

    public float CalculateDamage(Damage damage)
    {
        Moddable<float> finalDamage = new() { BaseValue = damage.Power.ModifiedValue };

        foreach (var resistance in Resistances.Where(r => r.Type is Damage.Type.None || r.Type == damage.DamageType))
        {
            finalDamage.Modifiers.Add(resistance.Amount);
        }

        return finalDamage.ModifiedValue;
    }
}

[System.Serializable]
public class DamageResistance
{
    [field: SerializeField] public Damage.Type Type { get; set; } = Damage.Type.None;

    [field: SerializeField] public PercentBonus Amount { get; set; }
}