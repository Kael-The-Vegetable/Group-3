using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField] private Camera _playerCamera;
    [Space]
    [SerializeField] private PlayerControl_Movement _movement;
    [SerializeField] private PlayerControl_Jumping _jumping;
    [Space]
    [SerializeField, ReadOnly] private Vector3 _velocity;
    [Header("Input values")]
    [SerializeField, ReadOnly] private Vector3 _inputDirection, _moveDirection;
    [SerializeField, ReadOnly] private bool _jumpPressed;

    public CharacterController Controller { get => _controller; private set => _controller = value; }
    public PlayerControl_Movement Movement { get => _movement; set => _movement = value; }
    public PlayerControl_Jumping Jumping { get => _jumping; set => _jumping = value; }


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        // Ensures the camera is never null.
        if (_playerCamera == null)
        {
            _playerCamera = Camera.main;
        }

        // add the falling multiplier to the player's gravity.
        _jumping.Gravity.Modifiers.Add(new ConditionalModifier<float>(
            modifier: _jumping.FallingGravityMod,
            condition: () => _velocity.y < 0));

        // add the air and ground speed modifiers to the base move speed
        _movement.MoveSpeed.Modifiers.Add(new ConditionalModifier<float>(
            modifier: _movement.GroundSpeed,
            condition: () => _jumping.IsGrounded));
        _movement.MoveSpeed.Modifiers.Add(new ConditionalModifier<float>(
            modifier: _movement.AirSpeed,
            condition: () => !_jumping.IsGrounded));
    }

    #region Movement
    public void Move_Control(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();

        _inputDirection = new Vector3(input.x, 0, input.y);
    }

    private void UpdateMove()
    {
        var cameraRotation = Quaternion.Euler(0, _playerCamera.transform.eulerAngles.y, 0);
        _moveDirection = cameraRotation * _inputDirection;

        if (_moveDirection != Vector3.zero)
        {
            transform.forward = _moveDirection;
        }

        _controller.Move(_movement.MoveSpeed.ModifiedValue * Time.deltaTime * _moveDirection);
    }
    #endregion

    #region Jumping
    public void Jump_Control(InputAction.CallbackContext context)
    {
        _jumpPressed = context.ReadValueAsButton();

        if (context.canceled && _velocity.y > 0 && !_jumping.IsGrounded)
        {
            Debug.Log("jump canceled");
            _velocity.y /= _jumping.JumpCancelMod;
        }
    }

    private void UpdateJump()
    {
        if (_jumping.IsGrounded && _velocity.y < 0)
        {
            _velocity.y = 0;
            _jumping.JumpCount = _jumping.MaxJumpCount.ModifiedValue;
        }

        if (_jumpPressed && _jumping.JumpCount > 0 && _velocity.y <= 0)
        {
            Debug.Log("jump");
            _jumping.JumpCount--;
            _velocity.y += Mathf.Sqrt(_jumping.JumpHeight.ModifiedValue * -2.0f * _jumping.Gravity.ModifiedValue);
        }

        _velocity.y += _jumping.Gravity.ModifiedValue * Time.deltaTime;
    }
    #endregion
    
    private void Update()
    {
        _jumping.IsGrounded = Controller.isGrounded;

        UpdateMove();
        UpdateJump();

        _controller.Move(_velocity * Time.deltaTime);
    }
}
