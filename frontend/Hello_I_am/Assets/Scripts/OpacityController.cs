using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityController : MonoBehaviour
{
    public float retentionTime;
    public float fadeOutRate;
    public float maxAlpha;

    private bool startFadeOut = false;
    private Color color;

    private void OnEnable()
    {
        color = gameObject.GetComponent<Image>().color;
        color.a = maxAlpha;
        gameObject.GetComponent<Image>().color = color;
        StartCoroutine(WaitFadeOut(retentionTime));
    }
    void Update()
    {
        if (startFadeOut)
        {
            color = gameObject.GetComponent<Image>().color;
            if (color.a <= 0.0f)
            {
                startFadeOut = false;
                gameObject.SetActive(false);
            }
            else
            {
                color.a -= fadeOutRate;
                gameObject.GetComponent<Image>().color = color;
            }
        }
    }

    private IEnumerator WaitFadeOut(float sec)
    {
        yield return new WaitForSeconds(sec);
        startFadeOut = true;
    }
}
