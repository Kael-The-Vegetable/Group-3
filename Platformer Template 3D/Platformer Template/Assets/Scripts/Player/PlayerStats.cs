using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;

    private PlayerControl_Jumping _jumping;
    private PlayerControl_Movement _movement;

    public Moddable<float> Gravity { get => _jumping?.Gravity; }
    public Moddable<float> JumpHeight { get => _jumping?.JumpHeight; }
    public Moddable<int> MaxJumpCount { get => _jumping?.MaxJumpCount; }

    public Moddable<float> MoveSpeed { get => _movement?.MoveSpeed; }

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
