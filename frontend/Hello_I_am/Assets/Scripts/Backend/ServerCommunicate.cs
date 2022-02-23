using System.Collections;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerCommunicate : MonoBehaviour
{
    // 첫 시작에 인터넷 연결 되었는지 확인
    private void Awake()
    {
        if(Application.internetReachability == NetworkReachability.NotReachable)
        {
            Debug.LogError("인터넷 연결 안 됨");
            // 팝업 띄우고 강제종료 하는게 좋을 듯
            Application.Quit();
        }
    }

    public void Start()
    {
        // 수정해주기
        // 로컬내부망 앞 0.0.0.*가 같아야 동일한 네트워크에 있는 것
        StartCoroutine(Post("서버주소/api/sentence-label/", "안녕"));
    }

    public IEnumerator Post(string url, string data)
    {
        /*
        byte[] dataToSend = new UTF8Encoding().GetBytes(data);

        UnityWebRequest request = UnityWebRequest.Post(url, data);
        request.uploadHandler = new UploadHandlerRaw(dataToSend);
        //json 헤더 추가
        request.SetRequestHeader("Content-Type", "application/json");



        yield return request.SendWebRequest();

        if( request != null)
        {
            string message = request.downloadHandler.text;
            Debug.Log("Server responded: "+ message);
        }

        else
        {
            Debug.Log("no response");
        }
        */
        

        /* 헤더 직접 지정하는 방법 -> 근데 이해를 잘 못하겠음.. 그냥 POST로 보내도 헤더는 POST가 되는 것이 아닌가?*/
        WWWForm form = new WWWForm();
        form.AddField("sentence", data);

        UnityWebRequest request = UnityWebRequest.Post(url, form);
        yield return request.SendWebRequest();

        if (request == null)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string message = request.downloadHandler.text;
            Debug.Log("Server responded: " + message);
        }
    }
}
