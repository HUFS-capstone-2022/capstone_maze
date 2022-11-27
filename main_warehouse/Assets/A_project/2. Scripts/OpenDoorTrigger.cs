using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{
    GameObject nearObject;
    GameObject equipKey;
    public GameObject[] keys;
    public bool[] hasKey;
    void Start()
    {

    }
    void Update()
    {
        KeyInteract();
    }
    void KeyInteract()
    {
        if(nearObject != null)
        {
            if(nearObject.tag == "Key")
            {
                KeyNumber keynum = nearObject.GetComponent<KeyNumber>();
                int keyIndex = keynum.value;
                hasKey[keyIndex] = true;

                Destroy(nearObject);

                equipKey = keys[keyIndex];
                equipKey.SetActive(true);

            }
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Key")
        {
            nearObject = other.gameObject;
            Debug.Log("key");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Key")
        {
            nearObject = null;
        }
    }
}
