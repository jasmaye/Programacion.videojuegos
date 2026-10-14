
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("HUD Elements")]
    public TextMeshProUGUI calmLightsText;
    public TextMeshProUGUI subtitleText;

    [Header("Accessibility Visual Feedback")]
    public GameObject visualEffectFlash;

    private void Awake()
    {
        // Check if we can use this UIManager.
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update the number of collected lights on the screen.
    public void UpdateCalmLights(int currentAmount, int totalAmount)
    {
        // Check if the text is ready before changing it.
        if (calmLightsText != null)
        {
            calmLightsText.text = "Calm Lights: " + currentAmount + " / " + totalAmount;
        }
    }

    // Show a subtitle when a sound happens.
    public void ShowSubtitle(string message, float duration)
    {
        // Check if the subtitle text is ready.
        if (subtitleText != null)
        {
            subtitleText.text = message;
            subtitleText.gameObject.SetActive(true);

            // Stop the previous timer so the new subtitle can show.
            CancelInvoke(nameof(HideSubtitle));

            // Hide the subtitle after the given time.
            Invoke(nameof(HideSubtitle), duration);
        }
    }

    private void HideSubtitle()
    {
        // Hide the subtitle if the text is available.
        if (subtitleText != null)
        {
            subtitleText.gameObject.SetActive(false);
        }
    }

    // Show a visual effect to help the player notice an event.
    public void TriggerVisualFeedback()
    {
        // Check if the visual effect is available.
        if (visualEffectFlash != null)
        {
            visualEffectFlash.SetActive(true);

            // Turn off the effect after a short time.
            Invoke(nameof(DisableVisualFeedback), 0.2f);
        }
    }

    private void DisableVisualFeedback()
    {
        // Turn off the effect if it is available.
        if (visualEffectFlash != null)
        {
            visualEffectFlash.SetActive(false);
        }
    }
}
