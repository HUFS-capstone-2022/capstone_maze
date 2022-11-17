using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class NormalManager : MonoBehaviour
{
    // SingleTon
    // Make one static instance
    private static NormalManager _instance;
    // Make property that help other scripts using instance
    public static NormalManager Instance
    {
        get
        {
            return _instance;
        }
        private set
        {
            _instance = value;
        }
    }

// Screen control values
    // Value for make Fade => (true = fade / false = non_fade)
    public bool FadeOut = true;
    // Value for make FadeIn
    public bool FadeIn = false;

    // Value for make GrayScale => (true = grayscale / false = non_grayscale)
    public bool GrayScale = false;
    // Value for check screen is already grayscale
    public bool isGray = false;



// Checking Values
    // Bool for moving player
    public bool playerMove = false;
    // Bool for making units move
    public bool unitMoving = false;
    // Bool for order to making units move.
    public bool makeUnitMove = false;

    // Value for caching player's transform component
    private Transform playerTr;

    // Base distance of units and player
    public float RadiusAroundTarget = 1.5f;


    // Awake()
    private void Awake()
    {
        // If do not have Instance, this object will be Instance
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        // If have Instance, Instance have to be only one. So, destroy this game object.
        Destroy(gameObject);
    }


    // Start
    void Start()
    {
        // Assign Components of player
        playerTr = GameObject.FindWithTag("PLAYER").GetComponent<Transform>();

        // move player to position
        playerMove = true;
    }


    // Update is called once per frame
    void Update()
    {
        // Fade Out

        // If screen is already gray
        if (isGray)
        {
            // get Nickname from UI

            // Fade Out
            FadeIn = true;

            isGray = false;
        }
    }
}
