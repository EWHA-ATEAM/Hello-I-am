using System.Collections;
using System.Text;
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
        StartCoroutine(Post("www.asdf.com/api/sentence_label", "배고파"));
    }

    public IEnumerator Post(string url, string data)
    {
        // url은 서버 주소..인듯 함 공식 홈페이지 예시에는 "www.my-server.com/myform",
        
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
        

        /* 헤더 직접 지정하는 방법 -> 근데 이해를 잘 못하겠음.. 그냥 POST로 보내도 헤더는 POST가 되는 것이 아닌가?
        WWWForm form = new WWWForm();
        form.AddField("Data", data);

        UnityWebRequest request = UnityWebRequest.Post(url, form);
        request.SetRequestHeader("Header", "POST");
        yield return request.SendWebRequest();

        if (request.isNetworkError || request.isHttpError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            Debug.Log("Complete!");
        }
        */
    }

}
