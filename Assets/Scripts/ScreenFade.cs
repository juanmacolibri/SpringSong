using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    Image panel;
    Color temp;
    // Start is called before the first frame update
    void Start()
    {
        temp = Color.black;
        panel = GetComponent<Image>();
        StartCoroutine(FadeScreen(-1));
    }

    public IEnumerator FadeScreen(float dir)
    {
        int n = 0;
        while (n < 100)
        {
            temp.a += dir/100;
            panel.color = temp;
            n++;
            yield return new WaitForSeconds(0.02f);
        }
    }
}
