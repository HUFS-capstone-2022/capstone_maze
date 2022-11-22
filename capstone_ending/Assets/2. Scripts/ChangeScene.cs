using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // player 게임 오브젝트가 충돌(트리거)감지
    private void OnTriggerEnter(Collider other)
    {
        // 각각 다른 씬(Scene) 호출
        
        // 상대 게임 오브젝트 태그가 TrueEnd 라면
        if (other.gameObject.name == "True")
        {
            Debug.Log("hit!");
            // StartCoroutine(FadeOut())
            SceneManager.LoadScene("True_End_Scene");
        }
        // 상대 게임 오브젝트 태그가 NormalEnd 라면
        else if (other.gameObject.name == "Normal")
        {
            Debug.Log("hit!");
            // StartCoroutine(FadeOut())
            SceneManager.LoadScene("Normal_End_Scene");
        }
        // 상대 게임 오브젝트 태그가 BadEnd 라면
        else if (other.gameObject.name == "Bad1" || other.gameObject.name == "Bad2")
        {
            Debug.Log("hit!");
            // StartCoroutine(FadeOut())
            SceneManager.LoadScene("Bad_End_Scene");
        }
    }
}
