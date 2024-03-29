using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class EnteringGame : MonoBehaviour
{
    // Start is called before the first frame updatepublic Image fadePanel;
    public Image fadePanel;
    public TextMeshProUGUI welcomeText;
    public float fadeDuration = 2.0f;
    public float textStayDuration = 0.1f; // How long to display the text before it starts to fade out

    void Start()
    {
        // Start the fade-in (from black to scene) and text display coroutine
        StartCoroutine(FadeInSceneAndText());
    }

IEnumerator FadeInSceneAndText()
{
    // Ensuring the panel and text start fully visible
    SetAlpha(fadePanel, 1f);
    SetAlpha(welcomeText, 1f);

    // Fade in the scene by fading out the panel
    float time = fadeDuration;
    while (time > 0f)
    {
        time -= Time.deltaTime;
        float alpha = time / fadeDuration;
        SetAlpha(fadePanel, alpha);
        yield return null;
    }

    // Waiting for the text to stay visible
    yield return new WaitForSeconds(textStayDuration);

    // Fade out the text
    time = fadeDuration; // Reset time for the text fade-out
    while (time > 0f)
    {
        time -= Time.deltaTime;
        float alpha = 1 - (time / fadeDuration); 
        SetAlpha(welcomeText, alpha);
        yield return null;
    }

    // Deactivating the text GameObject after fading out
    welcomeText.gameObject.SetActive(false);
}

    void SetAlpha(Graphic uiElement, float alpha)
    {
        Color color = uiElement.color;
        color.a = alpha;
        uiElement.color = color;
    }
}

