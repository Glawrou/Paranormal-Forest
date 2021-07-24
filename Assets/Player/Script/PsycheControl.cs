using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PsycheControl : MonoBehaviour
{

    public AudioSource Noise;
    public Rejeser rejeser;
    public Animator AnimPlayer;
    public PixelationPost PlayerEyes;

    public Image ScreamPan;

    [Range(0.001f, 1)]
    public float Psyche = 0;

    private float psyche;

    private void Update()
    {

        psyche = Psyche + rejeser.ConstPsihine();

        PlayerEyes._cellSize = psyche / 2;
        Noise.volume = psyche / 5f;


        //Смерть
        if(psyche >= 1 && AnimPlayer.GetBool("Die") == false)
        {
            AnimPlayer.SetBool("Die", true);
            StartCoroutine(Die());
        }
        
    }

    public void AddPsyche(float f)
    {
        
        Psyche += f;
        
    }
    
    IEnumerator Die()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public float GetPsyche()
    {
        return psyche;
    }

    public IEnumerator ScreamPanel()
    {
        ScreamPan.enabled = true;

        yield return new WaitForSeconds(0.2f);

        ScreamPan.enabled = false;
    }

}
