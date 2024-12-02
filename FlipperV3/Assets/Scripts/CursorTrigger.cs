using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorTrigger : MonoBehaviour
{
    public float hoverScaleFactor = 1.2f; // Facteur d'agrandissement
    public float transitionSpeed = 10f;  // Vitesse de la transition
    private Vector3 originalScale;       // Taille d'origine
    private Button lastHoveredButton;    // Dernier bouton survolé

    private void Update()
    {
        // Lancer un Raycast à la position du curseur
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

        if (hit && hit.collider.gameObject.GetComponent<Button>())
        {
            Button button = hit.collider.gameObject.GetComponent<Button>();

            // Si un nouveau bouton est détecté
            if (lastHoveredButton != button)
            {
                // Réinitialiser immédiatement la taille du bouton précédent
                if (lastHoveredButton != null)
                {
                    lastHoveredButton.transform.localScale = originalScale; // Taille d'origine
                }

                // Mettre à jour la référence et enregistrer la taille d'origine
                lastHoveredButton = button;
                originalScale = button.transform.localScale;
            }

            // Interpoler vers la taille agrandie
            button.transform.localScale = Vector3.Lerp(
                button.transform.localScale, 
                originalScale * hoverScaleFactor, 
                Time.unscaledDeltaTime * transitionSpeed
            );

            // Simuler un clic avec le bouton de la manette
            if (Input.GetKeyDown(KeyCode.JoystickButton1))
            {
                button.onClick.Invoke();
            }
        }
        else if (lastHoveredButton != null) // Aucun bouton survolé
        {
            // Réinitialiser la taille du dernier bouton
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