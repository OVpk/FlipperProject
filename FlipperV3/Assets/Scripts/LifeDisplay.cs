using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{

    public MenuManagerScript menuManager;

    public float maxLife = 100f;
    public float life = 100f;

    public Image lifeBarImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lifeBarImage.fillAmount = life / maxLife;
    }
    
    public float EditLife(float currentLife, float addedNumber)
    {
        currentLife += addedNumber;
        if (currentLife > 100)
        {
            currentLife = 100;
        }
        else if (currentLife < 0)
        {
            currentLife = 0;
            menuManager.GameOver();
        }

        return currentLife;
    }
}
