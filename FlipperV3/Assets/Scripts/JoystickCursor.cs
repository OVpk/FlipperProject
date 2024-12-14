using UnityEngine;

public class JoystickCursor : MonoBehaviour
{
    [SerializeField] private RectTransform cursor;
    [SerializeField] private RectTransform canvas;

    private Vector2 cursorPosition;
    public float moveSpeed;

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