using System.Collections;
using UnityEngine;

public class OutlinerIndication : MonoBehaviour
{
    [SerializeField] private AudioSource tick;
    [SerializeField] private AudioSource tack;
    
    public Material[] drumOutliners;
    public Material[] cymbalOutliners;
    public Material[] piano1Outliners;
    public Material[] piano2Outliners;
    public Material[] piano3Outliners;
    public Material[] piano4Outliners;
    
    private Coroutine currentCoroutine;
    private float delayTime = 0.5f;
    private bool isTickTurn;

    private void Start()
    {
        StopScintillement(drumOutliners);
        StopScintillement(cymbalOutliners);
        StopScintillement(piano1Outliners);
        StopScintillement(piano2Outliners);
        StopScintillement(piano3Outliners);
        StopScintillement(piano4Outliners);
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
}
