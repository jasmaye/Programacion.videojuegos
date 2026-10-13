using UnityEngine;
using TMPro;

/// <summary>
/// Manages UI elements, HUD updates, accessibility visual feedback, and subtitles.
/// </summary>
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
        if (instance == null)
        {
            instance = this;
        }
    }

    // Updates the HUD counter for collected items
    public void UpdateCalmLights(int currentAmount, int totalAmount)
    {
        if (calmLightsText != null)
        {
            calmLightsText.text = "Calm Lights: " + currentAmount + " / " + totalAmount;
        }
    }

    // Displays subtitle text for accessibility when audio events occur
    public void ShowSubtitle(string message, float duration)
    {
        if (subtitleText != null)
        {
            subtitleText.text = message;
            subtitleText.gameObject.SetActive(true);
            CancelInvoke(nameof(HideSubtitle));
            Invoke(nameof(HideSubtitle), duration);
        }
    }

    private void HideSubtitle()
    {
        if (subtitleText != null)
        {
            subtitleText.gameObject.SetActive(false);
        }
    }

    // Provides visual feedback alongside audio (redundant sensory feedback for accessibility)
    public void TriggerVisualFeedback()
    {
        if (visualEffectFlash != null)
        {
            visualEffectFlash.SetActive(true);
            Invoke(nameof(DisableVisualFeedback), 0.2f);
        }
    }

    private void DisableVisualFeedback()
    {
        if (visualEffectFlash != null)
        {
            visualEffectFlash.SetActive(false);
        }
    }
}