using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CursorTrigger : MonoBehaviour
{ 
    public LayerMask mask;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.zero);

            if (hit)
            {
                if (hit.collider.gameObject.GetComponent<Button>())
                {
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
            
         
        }
    
    }
}
