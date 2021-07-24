using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightControl : MonoBehaviour
{
    public Image pelena;

    public Light Lit;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && Lit.enabled == true)
        {
            Lit.range = 50f;
            Lit.spotAngle = 20f;
            Lit.intensity = 40f;
            pelena.enabled = true;
        }
        else if(Input.GetKeyUp(KeyCode.Mouse0) && Lit.enabled == true)
        {
            Lit.range = 17f;
            Lit.spotAngle = 70f;
            Lit.intensity = 1f;
            pelena.enabled = false;
        }


        if(Input.GetKey(KeyCode.Mouse0) == false)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1) && Lit.enabled == true)
            {
                Lit.enabled = false;
                pelena.enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.Mouse1) && Lit.enabled == false)
            {
                Lit.enabled = true;
                pelena.enabled = false;
            }
        }
        
    }
}
