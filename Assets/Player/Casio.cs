using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Casio : MonoBehaviour
{

    public PsycheControl Psyche;
    public Text CasioPanel;
    public Animation Anim;
   

    bool Check = false;
    bool ShowCasio = false;
    float dis = 0;

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (Anim.IsPlaying("ShowCasio") == false && Anim.IsPlaying("ShowBeakCasio") == false)
            {
                Anim.PlayQueued("ShowCasio");
                ShowCasio = true;
            }

        }
        else if (Input.GetKeyUp(KeyCode.Q) && ShowCasio == true)
        {
            if (Anim.IsPlaying("ShowCasio") == false && Anim.IsPlaying("ShowBeakCasio") == false)
            {
                Anim.PlayQueued("ShowBeakCasio");
                ShowCasio = false;
            }
        }
        else if(ShowCasio == true && Anim.IsPlaying("ShowCasio") == false && Anim.IsPlaying("ShowBeakCasio") == false && Input.GetKey(KeyCode.Q) == false)
        {
            ShowCasio = false;

            Anim.PlayQueued("ShowBeakCasio");
        }

        if (Check == false) { StartCoroutine(ChechCasio()); StartCoroutine(StepCounter()); }
    }

    IEnumerator ChechCasio()
    {
        Check = true;

        CasioPanel.text = "Пульс : " + (int)(75 + Random.Range(0, 6) + (145 * Psyche.GetPsyche())) + "\nШаги : " + (int)dis;
        
        yield return new WaitForSeconds(1f);

        Check = false;

    }

    IEnumerator StepCounter()
    {
        Vector3 pos0 = transform.position;

        yield return new WaitForSeconds(1f);

        Vector3 pos1 = transform.position;

        dis += Mathf.Abs(Vector3.Distance(pos0, pos1)) / 4;
    }
}
