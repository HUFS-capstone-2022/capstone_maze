using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueUnit : MonoBehaviour
{
    private Animator anim;
    private float timer = 0.0f;
    public bool animStart = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (TrueManager.Instance.FadeOut)
        {
            anim.SetBool("EndFading", true);
            TrueManager.Instance.FadeOut = false;
            animStart = true;
        }

        if (animStart)
        {
            timer += Time.deltaTime;
            if (timer > 2.2f)
            {
                Debug.Log("animing");
                animStart = false;
                TrueManager.Instance.makePlayerMoving = true;
            }
        }
    }
}
