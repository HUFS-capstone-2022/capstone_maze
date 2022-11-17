using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalPlayerCtrl : MonoBehaviour
{
    private Transform playerTr;
    private Vector3 targetPos = new Vector3(0.0f, 0.0f, 11.0f);
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerTr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // If Bad Scene Manager Instance's plyer move is true, Make player gameObject move.
        if (NormalManager.Instance.playerMove)
        {
            playerTr.position = Vector3.SmoothDamp(gameObject.transform.position, targetPos, ref velocity, smoothTime);
            if (transform.position.z >= 10.7f)
            {
                NormalManager.Instance.playerMove = false;
                NormalManager.Instance.makeUnitMove = true;
            }
        }
    }
}
