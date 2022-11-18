using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrueFading : MonoBehaviour
{
    // Value for Material
    private Material _material;

    // Lerp Value to make fading
    [Range(0.0f, 1.0f)]
    public float fadeLerpVal = 1.000f;

    // Awake()
    private void Awake()
    {
        // Add Shader in [Edit] - [Project Setting] - [Graphics] - [Always included shaders] for use this
        _material = new Material(Shader.Find("Hidden/Fade"));
    }

    // Start()
    void Start()
    {
        StartCoroutine(FadeOut());
        Debug.Log("FadeOut Coroutine called!!");
    }

    // Update()
    void Update()
    {
        if (TrueManager.Instance.makeFadeIn)
        {
            StartCoroutine(FadeIn());
            Debug.Log("Fade In Coroutine called!!");
            TrueManager.Instance.makeFadeIn = false;
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (fadeLerpVal == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }

        _material.SetFloat("_Fade", fadeLerpVal);
        Graphics.Blit(source, destination, _material);
    }

    // Fade In Coroutine
    IEnumerator FadeIn()
    {
        while (fadeLerpVal < 1.0f)
        {
            fadeLerpVal = Mathf.Round((fadeLerpVal + 0.1f) * 10) * 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        SceneManager.LoadScene("Boat_moving");
    }

    // Fade Out Coroutine
    IEnumerator FadeOut()
    {
        while (fadeLerpVal > 0.0f)
        {
            yield return new WaitForSeconds(0.1f);
            fadeLerpVal = Mathf.Round((fadeLerpVal - 0.05f) * 100) * 0.01f;
        }
        TrueManager.Instance.FadeOut = true;
    }
}
