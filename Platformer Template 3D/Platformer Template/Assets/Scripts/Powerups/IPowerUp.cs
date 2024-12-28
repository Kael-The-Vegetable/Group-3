using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPowerUp
{
    public void AddPowerup(PowerUpSlot.Type type);
    public void RemovePowerup(PowerUpSlot.Type type);

    public void WeaponAttack();
    public void RangedAttack();
    public void OnJump();
    public void OnTakeDamage();
}
