// using System.Collections;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.Networking;
// using Protocols;
// using Newtonsoft.Json;
// using System.Text;

// public class App : MonoBehaviour
// {
//     // : Objects
//     public Button BUTTON_Send;
//     public InputField IFIELD_Name;
//     public Text TEXT_Output;

//     // : Status
//     const string SERVER_HOST = "http://localhost:";
//     const int SERVER_PORT = 4000;

//     // Start is called before the first frame update
//     void Start()
//     {
//         this.BUTTON_Send.onClick.AddListener(() => 
//         {
//             // :: 객체 생성
//             string userName = IFIELD_Name.text;
//             Packets.find_req findRequest = new Packets.find_req(userName);

//             // :: 요청
//             this.StartCoroutine(this.RequestFind(findRequest));
//         });
//     }

//     // : Request
//     // :: IEnumerator 사용 이유 = SendWebRequest를 비동기 전송으로 하려고
//     private IEnumerator RequestFind(Packets.find_req packet)
//     {
//         // :: 직렬화
//         string json = JsonConvert.SerializeObject(packet);

//         // :: 요청객체 생성
//         string url = string.Format("{0}{1}", SERVER_HOST + SERVER_PORT, "/ranking");
//         UnityWebRequest webRequest = new UnityWebRequest(url, "POST");

//         // :: 바디
//         var bodyRaw = Encoding.UTF8.GetBytes(json);

//         // :: 이벤트
//         webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
//         webRequest.downloadHandler = new DownloadHanderBuffer();

//         // :: 헤더 설정
//         webRequest.SetRequestHeader("Content-Type", "application/json");

//         // :: 비동기 전송
//         yield return webRequest.SendWebRequest();

//         // :: 응답 : 에러 처리
//         if ( webRequest.isNetworkError || webRequest.isHttpError )
//         {
//             Debug.Log("www error");
//         }
//         else 
//         {
//             Debug.LogFormat("responseCode: {0}", webRequest.responseCode);

//             // :: 데이터 받기
//             byte[] resultRaw = webRequest.downloadHandler.data;
//             string resultJson = Encoding.UTF8.GetString(resultRaw);

//             Debug.Log(resultJson);

//             // :: 역직렬화
//             packet.find_res result = JsonConvert.DeserializeObject<Packets.find_res>(resultJson);

//             // :: UI 출력
//             string userOutput = "";
//             foreach(Packets.info_userData data in result.userData)
//             {
//                 userOutput += string.Format("");
//             }
//             this.SetText_Output(userOutput);
//         }
//     }

//     // : Set
//     private void SetText_Output(string text)
//     {
//         this.TEXT_Output.text = text;
//     }
// }
