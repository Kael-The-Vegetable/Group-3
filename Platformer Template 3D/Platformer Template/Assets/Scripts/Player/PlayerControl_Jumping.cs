using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerControl_Jumping
{
    [field: SerializeField] public bool IsGrounded { get; set; }
    [field: SerializeField] public Moddable<float> JumpHeight { get; set; }
    [field: SerializeField] public Moddable<int> MaxJumpCount { get; set; }
    [field: SerializeField] public float JumpCancelMod { get; set; }
    [field: SerializeField] public float FallingGravityMod { get; set; }
}
