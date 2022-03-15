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
    
    private string[] guideList = { "어디에 사는지", "무엇을 먹는지", "기분이 어떤지", "힘든 점이 있는지", "우리가 도와줄 것이 있는지", "동물가족들은 어떤지", "나이가 어떻게 되는지", "겉모습이 어떤지" };

    private ServerCommunicate serverCommunicate;

    private void OnEnable()
    {
        serverCommunicate = GameObject.Find("Canvas").GetComponent<ServerCommunicate>();
        if (!isRetry)
        {
            guideText.text = "인사를 나눠보세요!";
        }
        else
        {
            List<int> indexList = new List<int>();
            int count = 0;
            string guide = "아래의 정보와 관련된 질문을 해보세요!";
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
