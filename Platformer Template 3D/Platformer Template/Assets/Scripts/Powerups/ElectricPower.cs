using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElectricPower : MonoBehaviour, IPowerUp
{
    [SerializeField] private PlayerStats _playerStats;
    [Header("When on Head")]
    [SerializeField, ReadOnly] private bool _headEquipped;
    [SerializeField] private UnityEvent _onUseSpecial;
    [Header("When on Weapon")]
    [SerializeField, ReadOnly] private bool _weaponEquipped;
    [SerializeField] private Damage _meleeDamage;
    [Header("When on Arm")]
    [SerializeField, ReadOnly] private bool _armEquipped;
    [SerializeField] private Damage _rangedDamage;
    [Header("When on Body")]
    [SerializeField, ReadOnly] private bool _bodyEquipped;
    [SerializeField] private PercentBonus _healthBonus;
    [Header("When on Leg")]
    [SerializeField, ReadOnly] private bool _legEquipped;
    [SerializeField] private PercentBonus _moveSpeedBonus;

    void IPowerUp.AddPowerup(PowerUpSlot.Type type)
    {
        switch (type)
        {
            case PowerUpSlot.Type.Head:
                _headEquipped = true;
                break;
            case PowerUpSlot.Type.Body:
                _bodyEquipped = true;
                //_playerStats.MaxHealth.Modifiers.Add(_healthBonus);
                break;
            case PowerUpSlot.Type.Weapon:
                _weaponEquipped = true;
                break;
            case PowerUpSlot.Type.Arm:
                _armEquipped = true;
                break;
            case PowerUpSlot.Type.Leg:
                _legEquipped = true;
                _playerStats.MoveSpeed.Modifiers.Add(_moveSpeedBonus);
                break;
        }
    }

    void IPowerUp.OnJump()
    {
        throw new System.NotImplementedException();
    }

    void IPowerUp.OnTakeDamage()
    {
        throw new System.NotImplementedException();
    }

    void IPowerUp.RangedAttack()
    {
        throw new System.NotImplementedException();
    }

    void IPowerUp.RemovePowerup(PowerUpSlot.Type type)
    {
        switch (type)
        {
            case PowerUpSlot.Type.Head:
                _headEquipped = false;
                break;
            case PowerUpSlot.Type.Body:
                _bodyEquipped = false;
                //_playerStats.MaxHealth.Modifiers.Remove(_healthBonus);
                break;
            case PowerUpSlot.Type.Weapon:
                _weaponEquipped = false;
                break;
            case PowerUpSlot.Type.Arm:
                _armEquipped = false;
                break;
            case PowerUpSlot.Type.Leg:
                _legEquipped = false;
                _playerStats.MoveSpeed.Modifiers.Remove(_moveSpeedBonus);
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void IPowerUp.UseSpecial()
    {
        throw new System.NotImplementedException();
    }

    void IPowerUp.WeaponAttack()
    {
        throw new System.NotImplementedException();
    }
}
