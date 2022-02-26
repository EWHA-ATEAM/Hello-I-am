using UnityEngine;
using UnityEngine.EventSystems;

public class Test : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private SpeechToTextClova speechToTextClova;

    private void Start()
    {
        speechToTextClova = GameObject.Find("AppManager").GetComponent<SpeechToTextClova>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        speechToTextClova.startRecording();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        speechToTextClova.stopRecording();
    }
}
