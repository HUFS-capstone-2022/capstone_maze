using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // player ���� ������Ʈ�� �浹(Ʈ����)����
    private void OnTriggerEnter(Collider other)
    {
        // ���� �ٸ� ��(Scene) ȣ��
        
        // ��� ���� ������Ʈ �±װ� TrueEnd ���
        if (other.gameObject.name == "True")
        {
            Debug.Log("hit!");
            // StartCoroutine(FadeOut())
            SceneManager.LoadScene("True_End_Scene");
        }
        // ��� ���� ������Ʈ �±װ� NormalEnd ���
        else if (other.gameObject.name == "Normal")
        {
            Debug.Log("hit!");
            // StartCoroutine(FadeOut())
            SceneManager.LoadScene("Normal_End_Scene");
        }
        // ��� ���� ������Ʈ �±װ� BadEnd ���
        else if (other.gameObject.name == "Bad1" || other.gameObject.name == "Bad2")
        {
            Debug.Log("hit!");
            // StartCoroutine(FadeOut())
            SceneManager.LoadScene("Bad_End_Scene");
        }
    }
}
