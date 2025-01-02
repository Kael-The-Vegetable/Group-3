using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IPowerUp
{
    public Sprite Icon { get; }
    public void AddPowerup(PowerUpSlot.Type type);
    public void RemovePowerup(PowerUpSlot.Type type);

    public void UseSpecial();
    public void WeaponAttack();
    public void RangedAttack();
    public void OnJump();
    public void OnTakeDamage();
}
