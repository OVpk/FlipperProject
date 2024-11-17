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

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator Scintillement(Material[] instrumentOutliners)
    {
        foreach (var element in instrumentOutliners)
        {
            element.color = Color.red;
        }
        yield return new WaitForSeconds(0.5f);
        foreach (var element in instrumentOutliners)
        {
            element.color = Color.black;
        }
        yield return new WaitForSeconds(0.5f);
        currentCoroutine = StartCoroutine(Scintillement(instrumentOutliners));
    }

    public void StartScintillement(Material[] instrumentOutliners)
    {
        currentCoroutine = StartCoroutine(Scintillement(instrumentOutliners));
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
