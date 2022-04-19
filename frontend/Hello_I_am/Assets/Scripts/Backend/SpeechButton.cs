using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SpeechButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject speechGuide;
    [SerializeField]
    private GameObject timingText;

    private SpeechToTextClova speechToTextClova;
    private SpeechGuideController speechGuideController;
    private Coroutine coroutine;

    private void Start()
    {
        speechToTextClova = GameObject.Find("Canvas").GetComponent<SpeechToTextClova>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        speechGuide.SetActive(true);
        coroutine = StartCoroutine(Recording());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        speechGuide.SetActive(false);

        if (coroutine != null)
            StopCoroutine(coroutine);
        timingText.SetActive(false);
        speechToTextClova.stopRecording();
    }

    private IEnumerator Recording()
    {
        yield return new WaitForSeconds(0.5f);

        if(!speechGuide.GetComponent<SpeechGuideController>().isRetry)
            speechGuide.GetComponent<SpeechGuideController>().isRetry = true;
        timingText.SetActive(true);
        speechToTextClova.startRecording();
    }
}
