using UnityEngine;
using UnityEngine.UI;

public class CursorTrigger : MonoBehaviour
{
    public float hoveredScale = 1.2f;
    public float transitionSpeed = 10f;
    private Vector3 originalScale;
    private Button lastHoveredButton;

    public AudioSource sfxButton;
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        if (hit && hit.collider.gameObject.GetComponent<Button>())
        {
            
            
            Button button = hit.collider.gameObject.GetComponent<Button>();

            // Si un nouveau bouton est détecté
            if (lastHoveredButton != button)
            {
                sfxButton.Play();
                if (lastHoveredButton != null)
                {
                    lastHoveredButton.transform.localScale = originalScale;
                }
                
                lastHoveredButton = button;
                originalScale = button.transform.localScale;
            }
            
            button.transform.localScale = Vector3.Lerp(
                button.transform.localScale, 
                originalScale * hoveredScale, 
                Time.unscaledDeltaTime * transitionSpeed
            );
            
            
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                button.onClick.Invoke();
            }
        }
        else if (lastHoveredButton != null) // Aucun bouton survolé
        {
            
            lastHoveredButton.transform.localScale = Vector3.Lerp(
                lastHoveredButton.transform.localScale, 
                originalScale, 
                Time.unscaledDeltaTime * transitionSpeed
            );

            // Réinitialiser la référence si la taille est presque originale
            if (Vector3.Distance(lastHoveredButton.transform.localScale, originalScale) < 0.01f)
            {
                lastHoveredButton = null;
            }
        }
    }
}