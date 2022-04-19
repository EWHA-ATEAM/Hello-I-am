using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingText : MonoBehaviour
{
    [SerializeField]
    private Text loadingText;

    private float timer;
    private float cycleTime = 5.0f;
    private int idx;

    private string[] LT = { "대답 고민 중...", "인간 언어로 번역 중...", "동물 친구들한테\n조언을 구하는 중..." };

    private void OnEnable()
    {
        loadingText.text = "질문 이해 중...";
        timer = 0.0f;
        idx = Random.Range(0, LT.Length);
    }

    private void Update()
    {
        if(timer >= cycleTime)
        {
            timer = 0.0f;
            loadingText.text = LT[idx];
            idx = (idx + LT.Length - 1) % LT.Length;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }
}
