using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

// Manages the players equipped power ups
public class PlayerPowerUpManager : MonoBehaviour
{
    [SerializeField] private PowerUpSlot[] _powerUpSlots;

    [SerializeField] private ElectricPower _electricPower;

    public ElectricPower ElectricPower { get => _electricPower; set => _electricPower = value; }

    public void MeleeAttack_Control(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            foreach (var slot in _powerUpSlots.Where(p => p.SlotType == PowerUpSlot.Type.Weapon))
            {
                slot.WeaponAttack();
            }
        }
    }

    public void RangedAttack_Control(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            foreach (var slot in _powerUpSlots.Where(p => p.SlotType == PowerUpSlot.Type.Arm))
            {
                slot.RangedAttack();
            }
        }
    }

    public void SpecialAttack_Control(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            foreach (var slot in _powerUpSlots.Where(p => p.SlotType == PowerUpSlot.Type.Head))
            {
                slot.SpecialAttack();
            }
        }
    }
}
