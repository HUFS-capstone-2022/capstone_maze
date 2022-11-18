using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatMoving : MonoBehaviour
{
    private Transform boatTr;

    // 1. Values for Smooth Damp
    private Vector3 velocity = Vector3.zero;
    public float smoothTime = 2.0f;
    private Vector3 destination = new Vector3(500.0f, 0.43f, 0.61f);
    private bool moving = true;

    // Start is called before the first frame update
    void Start()
    {
        boatTr = GetComponent<Transform>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        // Make player gameObject move.
        if (moving)
        {
            boatTr.position = Vector3.SmoothDamp(boatTr.position, destination, ref velocity, smoothTime);

            // If Player is about arrived
            if (boatTr.position.x > 300.0f)
            {
                moving = false;
                Debug.Log("Player is arrived!");
                BoatManager.Instance.getDB = true;
            }
        }
    }
}
