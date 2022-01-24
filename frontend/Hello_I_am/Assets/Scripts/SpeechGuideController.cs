using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeechGuideController : MonoBehaviour
{
    [SerializeField]
    private Text recognizedText;

    private void OnEnable()
    {
        recognizedText.text = "";
    }

}
