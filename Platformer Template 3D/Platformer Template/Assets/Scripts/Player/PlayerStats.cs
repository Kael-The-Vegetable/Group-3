using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;

    private PlayerControl_Jumping _jumping;
    private PlayerControl_Movement _movement;

    public Moddable<float> Gravity => _jumping?.Gravity;
    public Moddable<float> JumpHeight => _jumping?.JumpHeight;
    public Moddable<int> MaxJumpCount => _jumping?.MaxJumpCount;

    public Moddable<float> MoveSpeed => _movement?.MoveSpeed;
    public Moddable<PercentBonus> GroundSpeed => _movement?.GroundSpeed;
    public Moddable<PercentBonus> AirSpeed => _movement?.AirSpeed;

    private void Start()
    {
        if (_controller == null)
        {
            _controller = GetComponentInChildren<PlayerController>();
        }
        _jumping = _controller.Jumping;
        _movement = _controller.Movement;
    }
}
