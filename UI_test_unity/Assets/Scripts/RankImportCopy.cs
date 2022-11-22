using System;
using System.Text;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.Networking;
using ProtocolsCopy;
using Newtonsoft.Json;
using TMPro;

public class RankImportCopy : MonoBehaviour
{
    // : Objects
    public Button LeftButton;
    public Button RightButton;
    public TextMeshProUGUI RankType;
    public TextMeshProUGUI PlayerName1;
    public TextMeshProUGUI PlayerName2;
    public TextMeshProUGUI PlayerName3;
    public TextMeshProUGUI PlayerName4;
    public TextMeshProUGUI PlayerName5;
    public TextMeshProUGUI PlayerName6;
    public TextMeshProUGUI PlayerName7;
    public TextMeshProUGUI PlayerName8;
    public TextMeshProUGUI ClearTime1;
    public TextMeshProUGUI ClearTime2;
    public TextMeshProUGUI ClearTime3;
    public TextMeshProUGUI ClearTime4;
    public TextMeshProUGUI ClearTime5;
    public TextMeshProUGUI ClearTime6;
    public TextMeshProUGUI ClearTime7;
    public TextMeshProUGUI ClearTime8;

    private Packets.find_res final;

    int ClearType = 2;

    // : Status
    const string SERVER_HOST = "http://localhost:";
    const int SERVER_PORT = 4000;

    void Awake() 
    {
        string userId = "5";
        Packets.find_req findRequest = new Packets.find_req(userId);
        // :: 요청
        this.StartCoroutine(this.RequestFind(findRequest));
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogFormat("start2 {0}", final);
        this.SetText_Output_Normal(final);
        LeftButton.onClick.AddListener(() => OnButtonClick(LeftButton));
        RightButton.onClick.AddListener(() => OnButtonClick(RightButton));
    }

    // : Request
    // :: IEnumerator 사용 이유 = SendWebRequest를 비동기 전송으로 하려고
    private IEnumerator RequestFind(Packets.find_req packet)
    {
        // :: 직렬화
        string json = JsonConvert.SerializeObject(packet);

        // :: 요청객체 생성
        string url = string.Format("{0}{1}", SERVER_HOST + SERVER_PORT, "/ranking");
        UnityWebRequest webRequest = new UnityWebRequest(url, "POST");

        // :: 바디
        var bodyRaw = Encoding.UTF8.GetBytes(json);

        // :: 이벤트
        webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
        webRequest.downloadHandler = new DownloadHandlerBuffer();

        // :: 헤더 설정
        webRequest.SetRequestHeader("Content-Type", "application/json");

        // :: 비동기 전송
        yield return webRequest.SendWebRequest();

        // :: 응답 : 에러 처리
        // if ( webRequest.isNetworkError || webRequest.isHttpError )
        if ((webRequest.result == UnityWebRequest.Result.ConnectionError) || (webRequest.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.Log("www error");
        }
        else 
        {
            Debug.LogFormat("responseCode: {0}", webRequest.responseCode);

            // :: 데이터 받기
            byte[] resultRaw = webRequest.downloadHandler.data;
            string resultJson = Encoding.UTF8.GetString(resultRaw);
            Debug.LogFormat("resultJson : {0}", resultJson);

            // :: 역직렬화
            final = JsonConvert.DeserializeObject<Packets.find_res>(resultJson);

        }
        webRequest.Dispose();
    }

    // : Set
    public void OnButtonClick(Button button)
    {
        if (button == LeftButton) {
            ClearType = ClearType - 1;
        }
        else if (button == RightButton) {
            ClearType = ClearType + 1;
        }

        switch (ClearType)
        {
            case < 2:
                RankType.text = "True Ending";
                ClearType = 1;
                SetText_Output_True(final);
                break;
            case > 2:
                RankType.text = "Bad Ending";
                ClearType = 3;
                SetText_Output_Bad(final);
                break;
            default:
                RankType.text = "Normal Ending";
                SetText_Output_Normal(final);
                break;
        }
    }

    private void SetText_Output_True(Packets.find_res final)
    {
        foreach(Packets.endType data in final.True)
        {
            this.WriteText1(data);
            this.WriteText2(data);
            this.WriteText3(data);
            this.WriteText4(data);
            this.WriteText5(data);
            this.WriteText6(data);
            this.WriteText7(data);
            this.WriteText8(data);
        }
    }

    private void SetText_Output_Normal(Packets.find_res final)
    {
        foreach(Packets.endType data in final.Normal)
        {
            this.WriteText1(data);
            this.WriteText2(data);
            this.WriteText3(data);
            this.WriteText4(data);
            this.WriteText5(data);
            this.WriteText6(data);
            this.WriteText7(data);
            this.WriteText8(data);
        }
    }

    private void SetText_Output_Bad(Packets.find_res final)
    {
        foreach(Packets.endType data in final.Bad)
        {
            this.WriteText1(data);
            this.WriteText2(data);
            this.WriteText3(data);
            this.WriteText4(data);
            this.WriteText5(data);
            this.WriteText6(data);
            this.WriteText7(data);
            this.WriteText8(data);
        }
    }

    private void WriteText1(Packets.endType data)
    {
        string userName = "";
        string userClearTime = "";
        if (data.rank1 != null)
        {
            foreach(Packets.info_userData text in data.rank1)
            {
                userName += string.Format("{0}", text.name);
                userClearTime += string.Format("{0}", text.clear_time.ToString("H:mm:ss"));
            }
            OutputText1(userName, userClearTime);
        }
    }

    private void WriteText2(Packets.endType data)
    {
        string userName = "";
        string userClearTime = "";
        if (data.rank2 != null)
        {
            foreach(Packets.info_userData text in data.rank2)
            {
                userName += string.Format("{0}", text.name);
                userClearTime += string.Format("{0}", text.clear_time.ToString("H:mm:ss"));
            }
            OutputText2(userName, userClearTime);
        }
    }

    private void WriteText3(Packets.endType data)
    {
        string userName = "";
        string userClearTime = "";
        if (data.rank3 != null)
        {
            foreach(Packets.info_userData text in data.rank3)
            {
                userName += string.Format("{0}", text.name);
                userClearTime += string.Format("{0}", text.clear_time.ToString("H:mm:ss"));
            }
            OutputText3(userName, userClearTime);
        }
    }

    private void WriteText4(Packets.endType data)
    {
        string userName = "";
        string userClearTime = "";
        if (data.rank4 != null)
        {
            foreach(Packets.info_userData text in data.rank4)
            {
                userName += string.Format("{0}", text.name);
                userClearTime += string.Format("{0}", text.clear_time.ToString("H:mm:ss"));
            }
            OutputText4(userName, userClearTime);
        }
    }
    
    private void WriteText5(Packets.endType data)
    {
        string userName = "";
        string userClearTime = "";
        if (data.rank5 != null)
        {
            foreach(Packets.info_userData text in data.rank5)
            {
                userName += string.Format("{0}", text.name);
                userClearTime += string.Format("{0}", text.clear_time.ToString("H:mm:ss"));
            }
            OutputText5(userName, userClearTime);
        }
    }
    
    private void WriteText6(Packets.endType data)
    {
        string userName = "";
        string userClearTime = "";
        if (data.rank6 != null)
        {
            foreach(Packets.info_userData text in data.rank6)
            {
                userName += string.Format("{0}", text.name);
                userClearTime += string.Format("{0}", text.clear_time.ToString("H:mm:ss"));
            }
            OutputText6(userName, userClearTime);
        }
    }
    
    private void WriteText7(Packets.endType data)
    {
        string userName = "";
        string userClearTime = "";
        if (data.rank7 != null)
        {
            foreach(Packets.info_userData text in data.rank7)
            {
                userName += string.Format("{0}", text.name);
                userClearTime += string.Format("{0}", text.clear_time.ToString("H:mm:ss"));
            }
            OutputText7(userName, userClearTime);
        }
    }

    private void WriteText8(Packets.endType data)
    {
        string userName = "";
        string userClearTime = "";
        if (data.rank8 != null)
        {
            foreach(Packets.info_userData text in data.rank8)
            {
                userName += string.Format("{0}", text.name);
                userClearTime += string.Format("{0}", text.clear_time.ToString("H:mm:ss"));
            }
            OutputText8(userName, userClearTime);
        }
    }

    private void OutputText1(string name, string clear_time)
    {
        this.PlayerName1.text = name;
        this.ClearTime1.text = clear_time;
    }

    private void OutputText2(string name, string clear_time)
    {
        this.PlayerName2.text = name;
        this.ClearTime2.text = clear_time;
    }

    private void OutputText3(string name, string clear_time)
    {
        this.PlayerName3.text = name;
        this.ClearTime3.text = clear_time;
    }

    private void OutputText4(string name, string clear_time)
    {
        this.PlayerName4.text = name;
        this.ClearTime4.text = clear_time;
    }

    private void OutputText5(string name, string clear_time)
    {
        this.PlayerName5.text = name;
        this.ClearTime5.text = clear_time;
    }

    private void OutputText6(string name, string clear_time)
    {
        this.PlayerName6.text = name;
        this.ClearTime6.text = clear_time;
    }

    private void OutputText7(string name, string clear_time)
    {
        this.PlayerName7.text = name;
        this.ClearTime7.text = clear_time;
    }

    private void OutputText8(string name, string clear_time)
    {
        this.PlayerName8.text = name;
        this.ClearTime8.text = clear_time;
    }
}
