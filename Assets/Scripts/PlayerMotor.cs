using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float gravity = -9.81f;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    // receives input from InputManager.cs and moves the player
    public void ProcessMove(Vector2 input)
    {
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;
        controller.Move(transform.TransformDirection(moveDirection) * walkSpeed * Time.deltaTime);
        playerVelocity.y += gravity * Time.deltaTime;
        if (controller.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f; // small negative value to keep the player grounded
        }
        controller.Move(playerVelocity * Time.deltaTime);
        Debug.Log(playerVelocity.y);
    }
}
