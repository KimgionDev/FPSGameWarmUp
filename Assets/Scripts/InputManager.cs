using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
    }

    private void OnEnable()     // Enable the input actions when the object is enabled
    {
        onFoot.Enable();
    }

    private void OnDisable()    // Disable the input actions when the object is disabled
    {
        onFoot.Disable();
    }

    private void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Move.ReadValue<Vector2>());
    }
}
