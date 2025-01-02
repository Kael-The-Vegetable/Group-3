using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_PowerupEquipmentSlot : MonoBehaviour
{
    [SerializeField] private PlayerPowerUpManager _powerupManager;
    [Space]
    [SerializeField] private Image _icon;
    [SerializeField] private PowerUpSlot.Type _slotType;

    public Image Icon { get => _icon; set => _icon = value; }
    public PowerUpSlot.Type SlotType { get => _slotType; set => _slotType = value; }
}

// I - inventory slot; E - Equipment slot
// [I] | H: [E][E][E][E]
// [I] | B: [E][E]
// [I] | W: [E][E][E]
// [I] | A: [E]
// [I] | L: [E][E]
