using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;

    public CharacterController Controller { get => _controller; private set => _controller = value; }

    [SerializeField] private Camera _playerCamera;
    [Space]
    [SerializeField] private PlayerControl_Movement _movement;
    [SerializeField] private PlayerControl_Jumping _jumping;
    [Space]
    [SerializeField] private Vector3 _velocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        
    }
}
