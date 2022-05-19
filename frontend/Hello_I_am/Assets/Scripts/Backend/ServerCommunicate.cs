using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ServerCommunicate : MonoBehaviour
{
    [SerializeField]
    private GameObject AnswerBox;
    [SerializeField]
    private Text AnswerText;

    [SerializeField]
    private GameObject loading;
    [Space(10)]
    [SerializeField]
    private string url;

    [HideInInspector]
    public bool receiveMotion = false;
    [HideInInspector]
    public int motionIndex = 0;


    //private int comm_num =0;

    

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
        form.AddField("animal", AppManager.instance.animal_index);
        form.AddField("sentence", data);

        UnityWebRequest request = UnityWebRequest.Post(url + "api/sentence-label/", form);

        yield return request.SendWebRequest();

        if (request == null)
        {
            loading.SetActive(false);
            Debug.LogError(request.error);
        }
        else
        {
            loading.SetActive(false);
            string message = request.downloadHandler.text;
            showAnswer(message);
            //comm_num = addCommunicationLog(comm_num, message);
        }
    }

    private IEnumerator Post(byte[] data)
    {
        WWWForm form = new WWWForm();
        // 필드 지정
        form.AddBinaryData("screenImage", data);
        Debug.Log("사진 보냄");

        UnityWebRequest request = UnityWebRequest.Post(url + "api/image-test/", form);
        yield return request.SendWebRequest();

        if (request == null)
        {
            Debug.LogError(request.error);
        }
        else
        {
            string message = request.downloadHandler.text;
            Debug.Log("사진 인식 결과값:" + message);
            
            motionIndex = int.Parse(message);
            receiveMotion = true;
        }
    }

    private void showAnswer(string msg)
    {
        AnswerText.text = msg;
        AnswerBox.SetActive(true);
    }


    /* 아마 사용하지 않을 함수 (chatscroll에 메세지 추가하는 함수)
    private int addCommunicationLog(int count, string msg)
    {
        int index = 1;
        if (count > 7)
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
    */



    // For test
    public void onclicktest()
    {
        //showAnswer("test!!");
        Debug.Log("밥먹었어 보냄");
        sendToServer("밥 먹었어?");
    }
    
}