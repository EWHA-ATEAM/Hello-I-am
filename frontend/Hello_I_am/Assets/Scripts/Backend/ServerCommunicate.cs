using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerCommunicate : MonoBehaviour
{
    [SerializeField]
    private GameObject chatScroll;
    [SerializeField]
    private GameObject loading;

    private int comm_num =0;

    private string url = "ec2서버주소/";

    public void sendToServer(string data)
    {
        StartCoroutine(Post(data));
    }

    public void sendToServer(byte[] data)
    {
        StartCoroutine(Post(data));
    }

    private IEnumerator Post(string data)
    {
        WWWForm form = new WWWForm();
        // 필드 지정
        form.AddField("sentence", data);

        UnityWebRequest request = UnityWebRequest.Post(url + "api/sentence-label/", form);
        yield return request.SendWebRequest();

        if (request == null)
        {
            Debug.LogError(request.error);
        }
        else
        {
            loading.SetActive(false);
            string message = request.downloadHandler.text;
            comm_num = addCommunicationLog(comm_num, message);
        }
    }

    private IEnumerator Post(byte[] data)
    {
        WWWForm form = new WWWForm();
        // 필드 지정
        form.AddBinaryData("screenImage", data);

        UnityWebRequest request = UnityWebRequest.Post(url + "api/모션인식어쩌구/", form);
        yield return request.SendWebRequest();

        if (request == null)
        {
            Debug.LogError(request.error);
        }
        else
        {
            loading.SetActive(false);
            string message = request.downloadHandler.text;
            Debug.LogError("사진 인식 결과값:" + message);
            // 처리하는 함수 호출
        }
    }




    private int addCommunicationLog(int count, string msg)
    {
        int index = 1;
        if (count > 3)
            index = 0;

        chatScroll.GetComponentInChildren<Text>().text = chatScroll.GetComponentInChildren<Text>().text.Substring(index) + "\n" + msg;
        count++;
        StartCoroutine(goBottom());
        return count;
    }

    private IEnumerator goBottom()
    {
        yield return new WaitForSeconds(0.1f * Time.deltaTime);
        chatScroll.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.0f;
    }

    // For test
    public void onclicktest()
    {
        comm_num = addCommunicationLog(comm_num, comm_num + "번째 시도");
        chatScroll.GetComponent<ScrollRect>().verticalNormalizedPosition = 0.0f;
    }
}