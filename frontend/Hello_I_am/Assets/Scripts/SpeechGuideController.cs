using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechGuideController : MonoBehaviour
{
    [SerializeField]
    private Text guideText;

    [HideInInspector]
    public bool isRetry = false;
    const int GUIDE_NUM = 3;
    
    private string[] guideList = { "어디에 살아?", "너는 뭘 먹어?", "오늘 기분이 어때?", "힘든 일은 없어?", "내가 뭘 하면 널 도울 수 있어?", "네 가족들은 어때?", "몇 살이야?", "넌 어떻게 생겼어?" };

    private ServerCommunicate serverCommunicate;

    private void OnEnable()
    {
        serverCommunicate = GameObject.Find("Canvas").GetComponent<ServerCommunicate>();
        if (!isRetry)
        {
            guideText.text = "동물과 인사를 나눠보세요!\n";
        }
        else
        {
            List<int> indexList = new List<int>();
            int count = 0;
            string guide = "아래의 정보와 관련된 질문을 해보세요!\n\n";
            int guideIndex = Random.Range(0, 8);
            while (count<GUIDE_NUM)
            {
                if (indexList.Contains(guideIndex))
                {
                    guideIndex = Random.Range(0, 8);
                }
                else
                {
                    indexList.Add(guideIndex);
                    count++;
                }
            }

            for(int i = 0; i < GUIDE_NUM; i++)
            {
                guide = guide + "\n" + guideList[indexList[i]];
            }
            guideText.text = guide;
        }
    }
}
