using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerInput.OnFootActions onFoot;

    private PlayerMotor motor;
    private PlayerLook look;

    private void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;
        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();
        // "Tôi muốn đăng ký (dấu +=) một hành động cho sự kiện onFoot.Jump.performed.
        // Hành động đó là: Khi sự kiện xảy ra, nó sẽ gửi cho tôi một gói thông tin là ctx
        // Nhưng tôi không quan tâm đến ctx, tôi chỉ muốn chạy lệnh motor.Jump() ngay lập tức."
        onFoot.Jump.performed += ctx => motor.Jump();
    }

    private void FixedUpdate()
    {
        motor.ProcessMove(onFoot.Move.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()     // Enable the input actions when the object is enabled
    {
        onFoot.Enable();
    }

    private void OnDisable()    // Disable the input actions when the object is disabled
    {
        onFoot.Disable();
    }
}
