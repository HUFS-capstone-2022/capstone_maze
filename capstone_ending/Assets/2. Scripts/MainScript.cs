using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScript : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 2.0f;
    public Color fadeColor;
    private Renderer render;
    private bool fadeDone = false;

    // Start is called before the first frame update
    void Start()
    {
        // �̰� ��
        PlayerPrefs.SetInt("ending", 0);
        Debug.Log("now value of PlayerPrefs_ending = " + PlayerPrefs.GetInt("ending"));

        render = GetComponent<Renderer>();
        if (fadeOnStart)
        {
            StartCoroutine(FadeIn());
        }

        DateTime start = DateTime.Now;
        Debug.Log("DateTime start : " + start);
        // string stStart = start.ToString(@"yyyyMMddHHmmss");
        string stStart = start.ToString(@"MM\/dd\/yyyy HH:mm:ss");
        string test = start.ToString(@"HH:mm:ss");
        PlayerPrefs.SetString("StartTime", stStart);
        PlayerPrefs.SetString("testTime", test);
        Debug.Log(PlayerPrefs.GetString("StartTime"));
        Debug.Log(test);
    }

    // ����
    public IEnumerator FadeIn()
    {
        float timer = 0.0f;
        while (timer < fadeDuration)
        {
            Color fiColor = fadeColor;
            fiColor.a = Mathf.Lerp(1, 0, timer / fadeDuration);
            render.material.SetColor("_Color", fiColor);

            timer += Time.deltaTime;
            yield return null;
        }
        Color fiColor2 = fadeColor;
        fiColor2.a = Mathf.Lerp(1, 0, timer / fadeDuration);
        render.material.SetColor("_Color", fiColor2);
    }

    // ����
    public IEnumerator FadeOut()
    {
        float timer = 0.0f;
        fadeDuration = 1.0f;
        while (timer < fadeDuration)
        {
            Color foColor = fadeColor;
            foColor.a = Mathf.Lerp(0, 1, timer / fadeDuration);
            render.material.SetColor("_Color", foColor);

            timer += Time.deltaTime;
            yield return null;
        }
        Color foColor2 = fadeColor;
        foColor2.a = Mathf.Lerp(0, 1, timer / fadeDuration);
        render.material.SetColor("_Color", foColor2);
        fadeDone = true;
    }

    // Ʈ���� �̰� ��
    private void OnTriggerEnter(Collider other)
    {
        // ���� �ٸ� ��(Scene) ȣ��

        // ��� ���� ������Ʈ �±װ� TrueEnd ���
        if (other.gameObject.name == "True")
        {
            StartCoroutine(FadeOut());
            // SceneManager.LoadScene("True_End_Scene");
            StartCoroutine(LoadSceneAsync("True_End_Scene"));
        }
        // ��� ���� ������Ʈ �±װ� NormalEnd ���
        else if (other.gameObject.name == "Normal")
        {
            StartCoroutine(FadeOut());
            // SceneManager.LoadScene("Normal_End_Scene");
            StartCoroutine(LoadSceneAsync("Normal_End_Scene"));
        }
        // ��� ���� ������Ʈ �±װ� BadEnd ���
        else if (other.gameObject.name == "Bad1" || other.gameObject.name == "Bad2")
        {
            StartCoroutine(FadeOut());
            // SceneManager.LoadScene("Bad_End_Scene");
            StartCoroutine(LoadSceneAsync("Bad_End_Scene"));
        }
    }

    IEnumerator LoadSceneAsync(string GameScene)
    {
        yield return null;

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(GameScene);
        asyncOperation.allowSceneActivation = false;

        while(!asyncOperation.isDone)
        {
            Debug.Log("asyncOperation progress:" + (asyncOperation.progress * 100) + "%");
            if (asyncOperation.progress >= 0.9f && fadeDone)
            {
                asyncOperation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
