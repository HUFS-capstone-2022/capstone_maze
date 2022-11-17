using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalFading : MonoBehaviour
{
    // Value for Material
    private Material _material;

    // Lerp Value
    [Range(0.0f, 1.0f)]
    public float fadeIOLerpVal = 0.0f;

    // Time Value
    public float inApplyTime = 3.0f;
    public float outApplyTime = 2.0f;
    private float passedTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Add Shader in [Edit] - [Project Setting] - [Graphics] - [Always included shaders] for use this
        _material = new Material(Shader.Find("Hidden/Fade"));
    }

    // Update is called once per frame
    void Update()
    {
        if (NormalManager.Instance.FadeIn)
        {
            if (passedTime <= inApplyTime)
            {
                passedTime += Time.deltaTime;
                fadeIOLerpVal = passedTime / inApplyTime;
            }
            else
            {
                fadeIOLerpVal = 1.0f;
                passedTime = 0.0f;
                // BadManager.Instance.FadeIn = false;
            }
        }

        if (NormalManager.Instance.FadeOut)
        {
            if (passedTime <= outApplyTime)
            {
                passedTime += Time.deltaTime;
                fadeIOLerpVal = 1 - (passedTime / outApplyTime);
            }
            else
            {
                passedTime = 0.0f;
                fadeIOLerpVal = 0.0f;
                NormalManager.Instance.FadeOut = false;
            }
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (fadeIOLerpVal == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }

        _material.SetFloat("_Fade", fadeIOLerpVal);
        Graphics.Blit(source, destination, _material);
    }
}
