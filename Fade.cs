using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    float duration = 1;
    float smoothness = 0.02f;

    void Start()
    {
        StartCoroutine("LerpColor");
    }

    IEnumerator LerpColor()
    {
        float progress = 0;
        float increment = smoothness / duration;
        while (progress < 1)
        {
            this.GetComponent<Image>().color = Color.Lerp(Color.black, Color.clear, progress);
            progress += increment;
            yield return new WaitForSeconds(smoothness);
        }
        this.gameObject.SetActive(false);
    }
}