using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
namespace Unity.XR.PXR
{
    public class testCtrl : MonoBehaviour
    {
        public float speed = 12.0f;
        private InputDevice currentController;
        private PXR_Input.Controller controller;
        private Vector2 axis2D;

        private Transform tr;
        private Transform camtr;
        private Camera cam;
        private float dirX;
        private float dirZ;
        private bool pax;

        private void Start()
        {
            currentController = InputDevices.GetDeviceAtXRNode(controller == PXR_Input.Controller.LeftController ? XRNode.LeftHand : XRNode.RightHand);
            tr = GetComponent<Transform>();
            camtr = Camera.main.GetComponent<Transform>();

        }
        private void Update()
        {
            //test();
            MovePrimary2DAxis();
        }
        private void test()
        {
            if (currentController.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out pax) && pax)
            {
                Debug.Log("primary2DClick");
                currentController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axis2D);
                Debug.Log("joystick dirx: "+axis2D.x+" / diry: ");
            }
        }
        private void MovePrimary2DAxis()
        {
            dirX = 0;
            dirZ = 0;
            if (currentController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axis2D))
            {
                var absX = Mathf.Abs(axis2D.x);
                var absY = Mathf.Abs(axis2D.y);
                if (absX > absY)
                {
                    if (axis2D.x > 0)
                    {
                        dirX += 1;
                    }
                    else if(axis2D.x < 0)
                    {
                        dirX -= 1;
                    }
                }
                else
                {
                    if (axis2D.y > 0)
                    {
                        dirZ += 1;
                    }
                    else if (axis2D.y < 0)
                    {
                        dirZ -= 1;
                    }
                }
            }
            var inputVector = new Vector3(dirX, 0, dirZ);
            //var inputDir = transform.TransformDirection(inputVector);
            var lookDir = new Vector3(0, camtr.eulerAngles.y, 0);
            var newDir = Quaternion.Euler(lookDir) * inputVector;
            //Vector3 moveDir = new Vector3(dir, 0, dirZ);
            //transform.Translate(moveDir * Time.deltaTime);
            transform.Translate(newDir * Time.deltaTime * speed);
        }
    }
}