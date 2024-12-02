using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlinerIndication : MonoBehaviour
{
    public AudioSource tick;
    public AudioSource tack;
    
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

    public bool isTickTurn;
    private IEnumerator Scintillement(Material[] instrumentOutliners, float delay)
    {
        if (isTickTurn)
        {
            tick.Play();
        }
        else
        {
            tack.Play();
        }

        isTickTurn = !isTickTurn;
        
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
        isTickTurn = true;
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
