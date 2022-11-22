using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;
using UnityEngine.XR;


public class HEADB : MonoBehaviour
{
    public Transform primary2DAxisTran;
    public PXR_Input.Controller controller;
    private InputDevice currentController;
    private Vector2 axis2D = Vector2.zero;
    private Transform camtr;
    private Camera cam;
    public float radius = 0.3f;
    LayerMask wallCol;
    // Start is called before the first frame update
    void Start()
    {
        currentController = InputDevices.GetDeviceAtXRNode(controller == PXR_Input.Controller.LeftController
                ? XRNode.LeftHand
                : XRNode.RightHand);
        currentController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axis2D);
        camtr = Camera.main.GetComponent<Transform>();
        wallCol = LayerMask.NameToLayer("Block");
    }

    // Update is called once per frame
    void Update()
    {
        int layerMask = ~(1 << wallCol);
        Collider[] colliders = Physics.OverlapSphere(camtr.transform.position, radius, layerMask);
        foreach(Collider col in colliders)
        {
            if (col.name == "PlayerL") continue;
            StartCoroutine("Blocking");
        }
    }
    IEnumerator Blocking()
    {
        while (true)
        {
            if (currentController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axis2D))
            {
                if (axis2D.y >= 0)
                {
                    while (!(axis2D.y > 0))
                    {
                        axis2D.x -= 1;
                        axis2D.y -= 1;
                    }
                }
            } 
            yield return null;
        }
    }
}
