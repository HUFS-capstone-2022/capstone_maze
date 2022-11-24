using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class trigger : MonoBehaviour
{
    void OnCollisionEnter(Collison col)
    {
        if(col.gameObject.CompareTag("MainCamera"))
        {
            SceneManager.LoadScene("Test_Scene")

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

}
