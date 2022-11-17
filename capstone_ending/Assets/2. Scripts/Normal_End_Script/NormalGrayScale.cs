using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalGrayScale : MonoBehaviour
{
    // Value for Material
    private Material _material;

    // Lerp Value
    [Range(0.0f, 1.0f)]
    public float grayScaleLerpVal = 0.0f;

    // Time Value
    public float applyTime = 2.0f;
    private float passedTime = 0.0f;

    void Start()
    {
        // Add Shader in [Edit] - [Project Setting] - [Graphics] - [Always included shaders] for use this
        _material = new Material(Shader.Find("Hidden/GrayScale"));
    }

    // Update is called once per frame
    void Update()
    {
        if (NormalManager.Instance.GrayScale)
        {
            if (passedTime <= applyTime)
            {
                passedTime += Time.deltaTime;
                grayScaleLerpVal = passedTime / applyTime;
            }
            else
            {
                passedTime = 0.0f;
                NormalManager.Instance.GrayScale = false;
                NormalManager.Instance.isGray = true;
            }
        }
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (grayScaleLerpVal == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }

        _material.SetFloat("_GrayScale", grayScaleLerpVal);
        Graphics.Blit(source, destination, _material);
    }
}
