using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Protocols;
using Newtonsoft.Json;
using System.Text;
using TMPro;

public class App : MonoBehaviour
{
    // : Objects
    public Button BUTTON_Send;
    public TMP_InputField IFIELD_UserId;
    public TMP_InputField IFIELD_ClearType;
    public TextMeshProUGUI TEXT_Output;

    // : Status
    const string SERVER_HOST = "http://localhost:";
    const int SERVER_PORT = 4000;

    // Start is called before the first frame update
    void Start()
    {
        this.BUTTON_Send.onClick.AddListener(() => 
        {
            // :: 객체 생성
            string userId_str = IFIELD_UserId.text;
            string clearType = IFIELD_ClearType.text;
            int userId_int = 0;
            for (int i = 0; i < userId_str.Length; i++)
            {
                userId_int = userId_int * 10 + (userId_str[i] - '0');
            }
            Packets.find_req findRequest = new Packets.find_req(userId_int, clearType);

            // :: 요청
            this.StartCoroutine(this.RequestFind(findRequest));
        });
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
            Packets.find_res result = JsonConvert.DeserializeObject<Packets.find_res>(resultJson);

            // :: UI 출력
            string userOutput = "";
            Debug.Log(result.userData);
            foreach(Packets.info_userData data in result.userData)
            {
                Debug.Log("here_2");
                Debug.Log(data);
                userOutput += string.Format("Id : {0}\n", data.id);
                // Debug.Log(data.userID);
                userOutput += string.Format("Name : {0}\n", data.name);
                // Debug.Log(data.userName);
                userOutput += string.Format("ClearTime : {0}\n", data.clear_time);
                // Debug.Log(data.userClearTime);
                userOutput += string.Format("ClearType : {0}\n", data.clear_type);
                // Debug.Log(data.userClearType);
            }
            this.SetText_Output(userOutput);
        }
        webRequest.Dispose();
    }

    // : Set
    private void SetText_Output(string text)
    {
        this.TEXT_Output.text = text;
    }
}
