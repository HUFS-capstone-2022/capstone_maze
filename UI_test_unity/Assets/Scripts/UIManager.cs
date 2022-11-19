using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public Button LeftButton;
    public Button RightButton;
    public TextMeshProUGUI RankText;

    int ClearType = 2;

    private UnityAction left;
    private UnityAction right;

    void start()
    {
        left = () => OnButtonClick(LeftButton);
        LeftButton.onClick.AddListener(left);
        right = () => OnButtonClick(RightButton);
        RightButton.onClick.AddListener(right);
    }
    public void OnButtonClick(Button button)
    {
        if (button == LeftButton) {
            ClearType--;
            ClearType = Math.Clamp(ClearType, 1, 3);
            Debug.Log($"left button {ClearType}");
        }
        else if (button == RightButton) {
            ClearType++;
            ClearType = Math.Clamp(ClearType, 1, 3);
            Debug.Log($"right button {ClearType}");
        }

        if ( ClearType == 1 ) 
        {
            RankText.text = "True Ending";
        }
        else if ( ClearType == 2 )
        {
            RankText.text = "Normal Ending";
        }
        else if ( ClearType == 3 )
        {
            RankText.text = "Bad Ending";
        }
    }
}
