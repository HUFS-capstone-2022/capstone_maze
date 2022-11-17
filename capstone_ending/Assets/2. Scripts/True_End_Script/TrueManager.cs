using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueManager : MonoBehaviour
{
// SingleTon
    // Make one static instance
    private static TrueManager _instance;
    // Make property that help other scripts using instance
    public static TrueManager Instance
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

// Values

// 0. Must need values
    // Value for caching player's transform component
    private Transform playerTr;

    // 1. Values for change animation of Units
    // Bool to make units greeting
    // public bool unitsGreeting = false;


    // 2. Make boat moving
    // Bool to make boat move

    // 3. Get DB data
    public bool getDB = false;

// 4. Make screen Fade In after get DB data
    public bool makeFadeIn = false;

    
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
