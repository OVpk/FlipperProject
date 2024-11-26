using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinerIndication : MonoBehaviour
{
    public Material[] drumOutliners;

    public Material[] cymbalOutliners;

    private Coroutine currentCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        StopScintillement(drumOutliners);
        StopScintillement(cymbalOutliners);
    }
    
    public float delayTime = 0.5f;

    public IEnumerator Scintillement(Material[] instrumentOutliners, float delay)
    {
        foreach (var element in instrumentOutliners)
        {
            element.color = Color.red;
        }
        yield return new WaitForSeconds(delay);
        foreach (var element in instrumentOutliners)
        {
            element.color = Color.black;
        }
        yield return new WaitForSeconds(delay);
        currentCoroutine = StartCoroutine(Scintillement(instrumentOutliners, delay*0.85f));
    }

    public void StartScintillement(Material[] instrumentOutliners)
    {
        currentCoroutine = StartCoroutine(Scintillement(instrumentOutliners, delayTime));
    }
    
    public void StopScintillement(Material[] instrumentOutliners)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        foreach (var element in instrumentOutliners)
        {
            element.color = Color.black;
        }
    }
}
