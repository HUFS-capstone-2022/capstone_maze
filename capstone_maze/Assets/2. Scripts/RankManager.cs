using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class RankManager : MonoBehaviour
{

    string[] RankType = new string[] {"True Ending", "Normal Ending", "Bad Ending"};
    int curRank;
    public Button RankLeft;
    public Button RankRight;
    public Text RankText;

    private UnityAction actionLeft;
    private UnityAction actionRight;

    void Start()
    {
        RankText.text = RankType[curRank];
        actionLeft = () => OnButtonClick(RankLeft.name);
        actionRight = () => OnButtonClick(RankRight.name);
    }

    public void OnButtonClick(string msg)
    {
        if (msg == "ButtonLeft") 
        {
            curRank--;
            curRank = Math.Clamp(curRank, 0, 2);
            RankText.text = RankType[curRank];
            Debug.Log("Click Button "+ msg + curRank);
        }    
        else if (msg == "ButtonRight")
        {
            curRank++;
            curRank = Math.Clamp(curRank, 0, 2);
            RankText.text = RankType[curRank];
            Debug.Log("Click Button "+ msg + curRank);
        }
        
    }
}
