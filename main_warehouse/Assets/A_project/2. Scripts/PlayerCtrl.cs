using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
namespace Unity.XR.PXR
{
    public class PlayerCtrl : MonoBehaviour
    {
        public float speed = 12.0f;
        public float shakeY = 2.0f;
        public float shakeTime =1.0f;
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
            // 음 오른손은 안들어오고있는거같은데..
            tr = GetComponent<Transform>();
            camtr = Camera.main.GetComponent<Transform>();
            StartCoroutine("walkShake");
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
                Debug.Log("joystick dirx: " + axis2D.x + " / diry: ");
            }
        }
        private void MovePrimary2DAxis()
        {
            dirX = 0;
            if (currentController.TryGetFeatureValue(CommonUsages.primary2DAxis, out axis2D))
            {
                    if (axis2D.y < 0)
                    {
                        return;
                    }
                var inputVector = new Vector3(dirX, 0, axis2D.y);
                //var inputDir = transform.TransformDirection(inputVector);
                var lookDir = new Vector3(0, camtr.eulerAngles.y, 0);
                var newDir = Quaternion.Euler(lookDir) * inputVector;
                //transform.Translate(moveDir * Time.deltaTime);
                transform.Translate(newDir * Time.deltaTime * speed);
            }
        }
        IEnumerator walkShake()
        {
            while (true)
            {
                if (!(axis2D.y <= 0)||axis2D.x!=0)
                {
                    Debug.Log("걸어!!");
                    var shakea = new Vector3(0, camtr.eulerAngles.y + shakeY, 0);
                    var shakeb = new Vector3(0, shakeY, 0);
                    var shakeDir = shakea + shakeb;
                    var originDir = new Vector3(0, 0, axis2D.y);
                    var newshake = Quaternion.Euler(shakeDir) * originDir;
                    transform.Translate(newshake*shakeTime*Time.deltaTime);
                    yield return new WaitForSeconds(1);
                }
                yield return null;
            }
        }
    }
}