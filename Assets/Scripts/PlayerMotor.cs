using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;
    [SerializeField] private bool isGrounded;
    [SerializeField] private float jumpHeight = 2f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
    }

    // receives input from InputManager.cs and moves the player
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * walkSpeed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // small negative value to keep the player grounded
        }
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y + "" + isGrounded);
    }

    public void Jump()
    {
        if (isGrounded)
        {                                                               // Công thức liên hệ gia tốc và quãng đường
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);  // v bình – v0 bình = 2.a.s
        }                                                               // v0 là playerVelocity.y (vận tốc ban đầu khi nhảy)
    }
}
