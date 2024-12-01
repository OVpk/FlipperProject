using UnityEngine;

public class JoystickCursor : MonoBehaviour
{
    public float moveSpeed;
    public RectTransform cursor;
    public RectTransform canvas;

    private Vector2 cursorPosition;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        cursorPosition = cursor.anchoredPosition;

        cursorPosition.x += horizontal * moveSpeed * Time.unscaledDeltaTime;
        cursorPosition.y += vertical * moveSpeed * Time.unscaledDeltaTime;

        cursorPosition.x = Mathf.Clamp(cursorPosition.x, 0, canvas.rect.width);
        cursorPosition.y = Mathf.Clamp(cursorPosition.y, 0, canvas.rect.height);

        cursor.anchoredPosition = cursorPosition;
    }
}