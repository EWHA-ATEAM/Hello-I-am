using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpeechButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private GameObject speechGuide;

    private SpeechToTextClova speechToTextClova;
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

        speechToTextClova.stopRecording();
    }

    private IEnumerator Recording()
    {
        yield return new WaitForSeconds(0.5f * Time.deltaTime);

        speechToTextClova.startRecording();
    }
}
