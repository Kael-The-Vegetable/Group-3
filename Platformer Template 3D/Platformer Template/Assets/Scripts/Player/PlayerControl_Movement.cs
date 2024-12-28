using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerControl_Movement
{
    [field: SerializeField] public Moddable<float> MoveSpeed { get; set; }
    [field: SerializeField] public Moddable<PercentBonus> GroundSpeed { get; set; }
    [field: SerializeField] public Moddable<PercentBonus> AirSpeed { get; set; }
}
