using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using JDoddsNAIT.Utilities.Components;

public class UIPowerupInventorySlot : MonoBehaviour
{
    [SerializeField] private int _count;
    [Space]
    [SerializeField] private Image _icon;
    [SerializeField] private HudLabel _countText;
    [SerializeField, ForceInterface(typeof(IPowerUp))] private Object _powerup;

    public int Count { get => _count; set => _count = value; }
    public Image Icon { get => _icon; set => _icon = value; }
    public HudLabel CountText { get => _countText; set => _countText = value; }
    public IPowerUp PowerUp { get => _powerup as IPowerUp; set => _powerup = value as Object; }
}
