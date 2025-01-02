using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_PowerupEquipmentSlot : MonoBehaviour
{

    [SerializeField] private PowerUpSlot.Type _slotType;
    public PowerUpSlot.Type SlotType { get => _slotType; set => _slotType = value; }
}
