using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSlot : MonoBehaviour
{
    public enum Type
    {
        Head, Body, Weapon, Arm, Leg
    }

    private IPowerUp _powerUp;
    
    [SerializeField] private Type _type;
    [SerializeField, ReadOnly] private string _currentPower;

    public Type SlotType { get => _type; set => _type = value; }
    public IPowerUp PowerUp
    {
        get => _powerUp; set
        {
            _powerUp.RemovePowerup(SlotType);
            _powerUp = value;
            value.AddPowerup(SlotType);

            _currentPower = value.ToString();
        }
    }

    public void WeaponAttack()
    {
        PowerUp?.WeaponAttack();
    }

    public void RangedAttack()
    {
        PowerUp?.RangedAttack();
    }

    public void OnJump()
    {
        PowerUp?.OnJump();
    }

    public void OnTakeDamage()
    {
        PowerUp?.OnTakeDamage();
    }

    public void SpecialAttack()
    {
        PowerUp?.UseSpecial();
    }
}
