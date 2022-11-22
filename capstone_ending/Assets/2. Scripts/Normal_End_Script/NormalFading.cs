using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFading : MonoBehaviour
{
// Value for Material
    private Material _material;

// Lerp Value to make fading
    [Range(0.0f, 1.0f)]
    public float fadeLerpVal = 1.000f;

// To start with FadeOut
    public bool start = true;

// Awake()
    private void Awake()
    {
        // Add Shader in [Edit] - [Project Setting] - [Graphics] - [Always included shaders] for use this
        _material = new Material(Shader.Find("Hidden/Fade"));
    }
    
// Update()
    void Update()
    {
        if (start)
        {
            StartCoroutine(FadeOut());
            Debug.Log("FadeOut Coroutine called!!");
            start = false;
        }

        if (NormalManager.Instance.makeFadeIn)
        {
            StartCoroutine(FadeIn());
            Debug.Log("Fade In Coroutine called!!");
            NormalManager.Instance.makeFadeIn = false;
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
            fadeLerpVal = Mathf.Round((fadeLerpVal + 0.02f) * 100) * 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
        Debug.Log("FadeIn Coroutine End!");
    }

// Fade Out Coroutine
    IEnumerator FadeOut()
    {
        while (fadeLerpVal > 0.0f)
        {
            fadeLerpVal = Mathf.Round((fadeLerpVal - 0.02f) * 100) * 0.01f;
            yield return new WaitForSeconds(0.02f);
        }
        NormalManager.Instance.makeStart = true;
        NormalManager.Instance.carMoves = true;
        NormalManager.Instance.carMoves2 = true;
        Debug.Log("FadeOut Coroutine End!");
    }
}
