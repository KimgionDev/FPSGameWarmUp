using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    private float xRotation = 0f;  // Vertical rotation

    [SerializeField ] private float xSensitivity = 30f;
    [SerializeField ] private float ySensitivity = 30f;

    // --- HÀM NÀY NÊN ĐƯỢC GỌI TỪ TRONG Update() HOẶC LateUpdate() ---
    public void ProcessLook(Vector2 lookInput)
    {
        // --- 1. LẤY GIÁ TRỊ "THÔ" TỪ INPUT ---
        // Lấy giá trị di chuyển ngang (trái/phải) của chuột.
        float mouseX = lookInput.x;
        // Lấy giá trị di chuyển dọc (lên/xuống) của chuột.
        float mouseY = lookInput.y;

        // --- 2. XỬ LÝ XOAY DỌC (NHÌN LÊN/XUỐNG) ---
        // Phần này chỉ xoay "cái đầu" (Camera), không xoay "cả cái thân" (Player).
        // Tính toán xem chúng ta sẽ xoay dọc bao nhiêu độ trong frame này.
        // Phải nhân với Time.deltaTime để tốc độ xoay mượt mà và không phụ thuộc vào FPS.
        float verticalRotationAmount = mouseY * ySensitivity * Time.deltaTime;

        // Trừ đi lượng xoay vào góc xoay hiện tại.
        // (Dùng dấu trừ '-' là một quy ước để khi di chuột LÊN thì camera nhìn LÊN).
        xRotation -= verticalRotationAmount;

        // "Kẹp" (Clamp) góc xoay lại, không cho phép nhìn quá cao hoặc quá thấp.
        // -90f là nhìn thẳng lên trời.
        // +90f là nhìn thẳng xuống đất.
        // Điều này ngăn người chơi bị "lộn cổ" ra đằng sau.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Áp dụng góc xoay cuối cùng vào "cái đầu" (Camera).
        // Dùng localRotation để camera chỉ xoay so với "cái thân" (Player).
        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // --- 3. XỬ LÝ XOAY NGANG (XOAY TRÁI/PHẢI) ---
        // Phần này xoay "cả cái thân" (Player).
        // Tính toán xem chúng ta sẽ xoay ngang bao nhiêu độ trong frame nàyx.
        float horizontalRotationAmount = mouseX * xSensitivity * Time.deltaTime;

        // Ra lệnh cho "cả cái thân" (transform của Player) xoay "thêm" một góc.
        // Vector3.up (trục Y) nghĩa là chúng ta xoay quanh trục thẳng đứng.
        transform.Rotate(Vector3.up * horizontalRotationAmount);
    }
}
