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

    private string url = "ec2서버주소/api/sentence-label/";

    public void sendToServer(string data)
    {
        StartCoroutine(Post(url, data));
    }
    
    private IEnumerator Post(string url, string data)
    {
        WWWForm form = new WWWForm();
        // 필드 지정
        form.AddField("sentence", data);

        UnityWebRequest request = UnityWebRequest.Post(url, form);
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